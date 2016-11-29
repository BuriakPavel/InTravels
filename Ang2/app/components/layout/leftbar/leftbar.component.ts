import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

@Component({
    selector: 'leftbar',
    templateUrl: './app/components/layout/leftbar/leftbar.component.html'
})
export class LeftbarComponent extends Locale implements OnInit {
     constructor(
        public locale: LocaleService, 
        public localization :LocalizationService, 
        private router: Router) {
            super(locale, localization);
    }

    ngOnInit() { }

    isAutenticate() {
        return localStorage.getItem("currentUser") != null;
    }
}