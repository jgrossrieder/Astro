using System;
using Astro.Common.Model.Names;

namespace Astro.Common.Model
{
    public class AstroManager
    {
        public AstroSign[] AllSigns { get; set; }

	    public AstroSign AriesSign { get; } = new AstroSign
	    {
		    Order = 1,
		    Name = Signs.SignAriesName,
		    Start = new DateTime(DateTime.Today.Year, 3, 21),
		    End = new DateTime(DateTime.Today.Year, 4, 20),
			IconUri =new Uri( "ms-appx:///Astro.model/Resources/aries.png")
	    };

	    public AstroSign TaurusSign { get; } = new AstroSign
	    {
		    Order = 2,
		    Name = Signs.SignTaurusName,
		    Start = new DateTime(DateTime.Today.Year, 4, 21),
		    End = new DateTime(DateTime.Today.Year, 5, 21),
			IconUri =new Uri( "ms-appx:///Astro.model/Resources/taurus.png")
	    };

	    public AstroSign GeminiSign { get; } = new AstroSign
	    {
		    Order = 3,
		    Name = Signs.SignGeminiName,
		    Start = new DateTime(DateTime.Today.Year, 5, 22),
		    End = new DateTime(DateTime.Today.Year, 6, 21),
			IconUri =new Uri("ms-appx:///Astro.model/Resources/gemini.png")
	    };

	    public AstroSign CancerSign { get; } = new AstroSign
	    {
		    Order = 4,
		    Name = Signs.SignCancerName,
		    Start = new DateTime(DateTime.Today.Year, 6, 22),
		    End = new DateTime(DateTime.Today.Year, 7, 22),
			IconUri =new Uri("ms-appx:///Astro.model/Resources/cancer.png")
	    };

	    public AstroSign LeoSign { get; } = new AstroSign
	    {
		    Order = 5,
		    Name = Signs.SignLeoName,
		    Start = new DateTime(DateTime.Today.Year, 7, 23),
		    End = new DateTime(DateTime.Today.Year, 8, 22),
			IconUri =new Uri( "ms-appx:///Astro.model/Resources/leo.png")
	    };

	    public AstroSign VirgoSign { get; } = new AstroSign
	    {
		    Order = 6,
		    Name = Signs.SignVirgoName,
		    Start = new DateTime(DateTime.Today.Year, 8, 23),
		    End = new DateTime(DateTime.Today.Year, 9, 23),
			IconUri =new Uri( "ms-appx:///Astro.model/Resources/virgo.png")
	    };

	    public AstroSign LibraSign { get; } = new AstroSign
	    {
		    Order = 7,
		    Name = Signs.SignLibraName,
		    Start = new DateTime(DateTime.Today.Year, 9, 24),
		    End = new DateTime(DateTime.Today.Year, 10, 23),
			IconUri =new Uri( "ms-appx:///Astro.model/Resources/libra.png")
	    };

	    public AstroSign ScorpioSign { get; } = new AstroSign
	    {
		    Order = 8,
		    Name = Signs.SignScorpioName,
		    Start = new DateTime(DateTime.Today.Year, 10, 24),
		    End = new DateTime(DateTime.Today.Year, 11, 22),
			IconUri =new Uri( "ms-appx:///Astro.model/Resources/scorpio.png")
	    };

	    public AstroSign SagittariusSign { get; } = new AstroSign
	    {
		    Order = 9,
		    Name = Signs.SignSagittariusName,
		    Start = new DateTime(DateTime.Today.Year, 11, 23),
		    End = new DateTime(DateTime.Today.Year, 12, 21),
			IconUri =new Uri( "ms-appx:///Astro.model/Resources/sagittarus.png")
	    };

	    public AstroSign CapricornSign { get; } = new AstroSign
	    {
		    Order = 10,
		    Name = Signs.SignCapricornName,
		    Start = new DateTime(DateTime.Today.Year, 12, 22),
		    End = new DateTime(DateTime.Today.Year + 1, 1, 20),
			IconUri =new Uri( "ms-appx:///Astro.model/Resources/capricorn.png")
	    };

	    public AstroSign AquariusSign { get; } = new AstroSign
	    {
		    Order = 11,
		    Name = Signs.SignAquariusName,
		    Start = new DateTime(DateTime.Today.Year + 1, 1, 21),
		    End = new DateTime(DateTime.Today.Year + 1, 2, 19),
			IconUri =new Uri( "ms-appx:///Astro.model/Resources/aquarius.png")
	    };

	    public AstroSign PiscesSign { get; } = new AstroSign
	    {
		    Order = 12,
		    Name = Signs.SignPiscesName,
		    Start = new DateTime(DateTime.Today.Year + 1, 2, 20),
		    End = new DateTime(DateTime.Today.Year + 1, 3, 20),
			IconUri =new Uri( "ms-appx:///Astro.model/Resources/pisces.png")
	    };

		public static AstroManager Instance { get; private set; } = new AstroManager();

        private AstroManager()
        {
            //  ResourceManager resManager = new ResourceManager("Images", GetType().Assembly);
            AllSigns = new[]
            {
				AriesSign,
				TaurusSign,
				GeminiSign,
				CancerSign,
				LeoSign,
				VirgoSign,
				LibraSign,
				ScorpioSign,
				SagittariusSign,
				CapricornSign,
				AquariusSign,
				PiscesSign
			};
        }
    }
}
