import { Component } from '@angular/core';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

@Component({
    selector: 'my-app',
    templateUrl: './app/app.component.html',
    providers: [LocaleService, LocalizationService]
})
export class AppComponent extends Locale {

    constructor(public locale: LocaleService, public localization: LocalizationService) {
        super(locale, localization);
        // Adds the languages (ISO 639 two-letter or three-letter code).
        var languages = ['en', 'uk', 'ru'];
        this.locale.addLanguages(languages);

        var lang = navigator.language.substring(0, 2);
        if (languages[0] == lang) {
            this.locale.definePreferredLocale('en', 'US', 30);
        }
        else if (languages[1] == lang) {
            this.locale.definePreferredLocale('uk', 'UA', 30);
        }
        else if (languages[2] == lang) {
            this.locale.definePreferredLocale('ru', 'RU', 30);
        }
        else {
            this.locale.definePreferredLocale('en', 'US', 30);
        }
        // Required: default language, country (ISO 3166 two-letter, uppercase code) and expiry (No days). If the expiry is omitted, the cookie becomes a session cookie.
        // Selects the default language and country, regardless of the browser language, to avoid inconsistencies between the language and country.

        // Required: initializes the translation provider with the given path prefix.

        // api: 'http://localhost/InTravels.WebAPI/api/LocalizationApi?culture=';
        this.localization.addProvider('../app/data/localization-', 'json', false);
        this.localization.updateTranslation(); // Need to update the translation.

    }
}