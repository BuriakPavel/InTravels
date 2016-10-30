import { Component } from '@angular/core';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

@Component({
    selector: 'header',
    templateUrl: './app/components/layout/header/header.component.html'
})
export class HeaderComponent {
    constructor(public localization: LocalizationService) {
        // Initializes LocalizationService: asynchronous loading.
        this.localization.translationProvider('http://localhost/InTravels.WebAPI/api/LocalizationApi?culture=', 'json', true);  // Required: initializes the translation provider with the given path prefix.
        this.localization.updateTranslation(); // Need to update the translation.

    }
}
