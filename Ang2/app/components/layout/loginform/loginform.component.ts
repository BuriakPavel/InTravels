import { Component, OnInit } from '@angular/core';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

@Component({
    moduleId: module.id,
    selector: 'loginform',
    templateUrl: 'loginform.component.html'
})
export class LoginformComponent extends Locale implements OnInit {
    constructor(
        public locale: LocaleService, 
        public localization :LocalizationService) {
            super(locale, localization);
    }

    ngOnInit() { }
}