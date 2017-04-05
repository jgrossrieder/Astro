using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Astro.Common.Common;
using Astro.Common.Model;
using Astro.Retrievers.Common;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Ninject;
using Ninject.Extensions.Logging;

namespace Astro.Retrievers.TwentyMinRetriever
{
	class TwentyMinRetriever:IRetriever
	{
		private const string URL_FORMAT = "http://www.20min.ch/printpdf/VD_{0:yyyyMMdd}.pdf";
		private const string LOCAL_FILE_FORMAT = "VD_{0:yyyyMMdd}.pdf";
		private const string PAGE_WITH_HOROSCOPE_MARKER = "Les astres et vous";

		private const string HOROSCOPE_PATTERN =@"\s__SIGN__([\S\s]*?)AMOUR\s*([★✩]{1,4})\sJOB\s*([★✩]{1,4})\sVITALITÉ\s*([★✩]{1,4})";


		private ILogger _logger = InstanceContext.Instance.Kernel.Get<ILoggerFactory>().GetCurrentClassLogger();

		public async Task<HoroscopeSet> RetrieveHoroscope(DateTime date)
		{
			String pdfUrl = BuildPdfURL(date);
			String localPath = BuildLocalFilePath(date);
			await DownloadFile(pdfUrl, localPath);
			HoroscopeSet horoscope = ExtractHoroscope(date,localPath);
			
			return horoscope;
		}

		private HoroscopeSet ExtractHoroscope(DateTime date, string localPath)
		{
			PdfReader pdfReader = new PdfReader(localPath);
			_logger.Info($"Extracting horoscope from {localPath}");
			String pageAsText = FindPageWithHoroscope(pdfReader);
			List<Horoscope> horoscopes = ParseHoroscope(pageAsText);

			pdfReader.Close();

			return new HoroscopeSet() { Time = date , Horoscopes = new ObservableCollection<Horoscope>(horoscopes) };
		}

		private List<Horoscope> ParseHoroscope(string pageAsText)
		{
			List< Horoscope> horoscopes = new List<Horoscope>();
			foreach (AstroSign sign in AstroManager.Instance.AllSigns)
			{
				Regex regex = new Regex(HOROSCOPE_PATTERN.Replace("__SIGN__",sign.Name.ToUpper()), RegexOptions.CultureInvariant | RegexOptions.Multiline);
				Match match = regex.Match(pageAsText);
				if (!match.Success)
				{
					_logger.Error($"Unable to find the sign {sign.Name}");
					continue;
				}
				Horoscope horoscope = new Horoscope() {Sign = sign, GlobalText = FormatText(match.Groups[1].Value)};
				horoscope.Topics.Add(new HoroscopeTopic(){Title = "Amour", TotalStars = 4, Stars = match.Groups[2].Value.Count(c=>c== '★') });
				horoscope.Topics.Add(new HoroscopeTopic(){Title = "Job", TotalStars = 4, Stars = match.Groups[3].Value.Count(c=>c== '★') });
				horoscope.Topics.Add(new HoroscopeTopic(){Title = "Vitalité", TotalStars = 4, Stars = match.Groups[4].Value.Count(c=>c== '★') });
				horoscopes.Add(horoscope);
			}
			return horoscopes;
		}

		private string FormatText(string input)
		{
			input =input.Replace("-\n", "");
			input =input.Replace("\n", "");
			return input.Trim();
		}

		private String FindPageWithHoroscope(PdfReader pdfReader)
		{
			ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
			for (int page = 1; page <= pdfReader.NumberOfPages; page++)
			{
				string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
				if (currentPageText.Contains(PAGE_WITH_HOROSCOPE_MARKER))
				{
					_logger.Info($"Found horoscope on page {page}");
					return currentPageText;
				}
			}

			throw new InvalidOperationException("Unable to find the horoscope on today 20Min");
		}

		private string BuildLocalFilePath(DateTime date)
		{
			return String.Format(LOCAL_FILE_FORMAT, date);
		}

		private string BuildPdfURL(DateTime date)
		{
			return String.Format(URL_FORMAT, date);
		}

		private async Task DownloadFile(string url, string targetFilePath)
		{
			if (File.Exists(targetFilePath))
			{
				_logger.Warn($"PDF {targetFilePath} already existing using it directly");
			}
			else
			{
				using (WebClient wc = new WebClient())
				{
				_logger.Info($"Downloading {url} to {targetFilePath}");
				 await wc.DownloadFileTaskAsync(url, targetFilePath);
				}
			}
		}
	}
}
