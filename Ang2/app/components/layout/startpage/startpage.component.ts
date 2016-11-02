import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

@Component({
    selector: 'startpage',
    templateUrl: './app/components/layout/startpage/startpage.component.html'
})
export class StartpageComponent extends Locale implements OnInit {
    constructor(public locale: LocaleService, public localization: LocalizationService, private router: Router) {
        super(locale, localization);
    }

    ngOnInit() { };

    gotoHome(): void {
        this.router.navigate(['/home']);
    }
    
    public ChangeCulture(language: string, country: string) {
        this.locale.setCurrentLocale(language, country);
        //this.locale.setCurrentCurrency(currency);
    }
}