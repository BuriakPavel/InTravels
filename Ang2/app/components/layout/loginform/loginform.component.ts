import { Component, OnInit } from '@angular/core';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';
import { Router } from '@angular/router';

import { AuthenticationService } from '../../../services/authentication.service';

@Component({
    moduleId: module.id,
    selector: 'loginform',
    templateUrl: 'loginform.component.html'
})
export class LoginFormComponent extends Locale implements OnInit {
    model: any = {};
    loading = false;
    error = '';

    constructor(
        private router: Router,
        public locale: LocaleService, 
        public localization :LocalizationService,
        private authenticationService: AuthenticationService) {
            super(locale, localization);
    }

    ngOnInit() {
        // reset login status
        this.authenticationService.logout();
    }

    login() {
        this.loading = true;
        this.authenticationService.login(this.model.username, this.model.password)
            .subscribe(result => {
                if (result === true) {
                    console.log("navigate to profile page");
                    this.router.navigate(['/home/profile']);
                } else {
                    this.error = 'Username or password is incorrect';
                    this.loading = false;
                }
            });
    }

}