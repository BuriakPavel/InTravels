import { Component } from '@angular/core';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

@Component({
    selector: 'header',
    templateUrl: './app/components/layout/header/header.component.html'
})
export class HeaderComponent extends Locale {
    constructor(public locale: LocaleService, public localization: LocalizationService) {
        super(locale, localization)
    }
    // Sets a new locale & currency.
    public ChangeCulture(language: string, country: string) {
        this.locale.setCurrentLocale(language, country);
        //this.locale.setCurrentCurrency(currency);
    }
}
