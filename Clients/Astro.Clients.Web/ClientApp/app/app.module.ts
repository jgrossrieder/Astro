import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HoroscopeComponent } from './components/horoscope/horoscope.component';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HoroscopeComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'horoscope', pathMatch: 'full' },
            { path: 'horoscope', component: HoroscopeComponent },
            { path: '**', redirectTo: 'horoscope' }
        ])
    ]
})
export class AppModule {
}
