import { Component, AfterViewInit } from '@angular/core';
import $ from 'jquery';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
    ngAfterViewInit() {
        //TODO INITIALIZE NIFTY
        //$(document).trigger('nifty.ready');
    }
}
