import { Component, ViewChild } from '@angular/core';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';

import { Router } from '@angular/router'
import { Locale, LocaleService, LocalizationService } from 'angular2localization';
import { AuthenticationService } from '../../../services/authentication.service';

@Component({
    selector: 'header',
    templateUrl: './app/components/layout/header/header.component.html'
})
export class HeaderComponent extends Locale {
    @ViewChild('loginFormModal')
    loginFormModal: ModalComponent;

    activeLang: string;

    constructor(public locale: LocaleService, public localization: LocalizationService, private authenticationService: AuthenticationService, private router: Router) {
        super(locale, localization)
        this.activeLang = this.locale.getCurrentLanguage();
    }
    // Sets a new locale & currency.
    public ChangeCulture(language: string, country: string) {
        this.locale.setCurrentLocale(language, country);
        this.activeLang = language;
        //this.locale.setCurrentCurrency(currency);
    }

    isAutenticate() {
        return localStorage.getItem("currentUser") != null;
    }

    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/home']);
    }

    openLoginForm() {
        this.loginFormModal.open();
    }
}
