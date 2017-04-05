import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'horoscope',
    templateUrl: './horoscope.component.html'
})
export class HoroscopeComponent {
    public horoscopes: Horoscope[];

    constructor(http: Http) {
        //This is dirty, have to create a service after.
        http.get('/api/horoscopes').subscribe(result => {
            this.horoscopes = result.json() as Horoscope[];
        });
    }
    public iterate(biggest: number): Array<number> {
        let list: Array<number> = new Array<number>(biggest);
        for (let i = 1; i <= biggest; i++) {
            list.push(i);
        }
        return list;
    }
}
interface AstroSign {
    name: string;
    order: number;
    start: Date;
    end: Date;
}
interface HoroscopeTopic {
    title: string;
    totalStars: number;
    stars: number;
}

interface Horoscope {
    sign: AstroSign;
    globalText: string;
    topics: HoroscopeTopic[];
}

