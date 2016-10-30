import { Component } from '@angular/core';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

@Component({
    selector: 'my-app',
    templateUrl: './app/app.component.html'
})
export class AppComponent extends Locale {

    constructor(public locale: LocaleService, public localization: LocalizationService) {
        super(locale, localization);

        // Adds the languages (ISO 639 two-letter or three-letter code).
        this.locale.addLanguages(['en', 'uk', 'ru']);

        // Required: default language, country (ISO 3166 two-letter, uppercase code) and expiry (No days). If the expiry is omitted, the cookie becomes a session cookie.
        // Selects the default language and country, regardless of the browser language, to avoid inconsistencies between the language and country.
        this.locale.definePreferredLocale('en', 'US', 30);

        // Initializes LocalizationService: asynchronous loading.
        this.localization.translationProvider('http://localhost/InTravels.WebAPI/api/LocalizationApi?culture=', 'json', true); // Required: initializes the translation provider with the given path prefix.
        this.localization.updateTranslation(); // Need to update the translation.
    }

    // Sets a new locale & currency.
    public ChangeCulture(language: string, country: string) {
        this.locale.setCurrentLocale(language, country);
        //this.locale.setCurrentCurrency(currency);
    }
}