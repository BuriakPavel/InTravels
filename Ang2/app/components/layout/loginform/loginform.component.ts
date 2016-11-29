import { Component, OnInit, ViewChild, AfterViewInit, ViewEncapsulation } from '@angular/core';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';
import { Router } from '@angular/router';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';

import { FormsErrors } from '../../../classes/serviseResponce';

import { AuthenticationService } from '../../../services/authentication.service';

@Component({
    moduleId: module.id,
    selector: 'loginform',
    templateUrl: 'loginform.component.html',
    styles: [
        `.input-group-addon {
            background-color: #df691a;
            border-radius: 5px;
        }`
    ],
    encapsulation: ViewEncapsulation.None
})
export class LoginFormComponent extends Locale implements OnInit, AfterViewInit {
    model: LoginFormModel;

    @ViewChild('loginformModal')
    loginformModal: ModalComponent;

    backdropOptions = [true, false, 'static'];
    animation: boolean = true;
    keyboard: boolean = true;
    backdrop: string | boolean = true;
    css: boolean = false;


    constructor(
        private router: Router,
        public locale: LocaleService,
        public localization: LocalizationService,
        private authenticationService: AuthenticationService) {
        super(locale, localization);

        this.model = new LoginFormModel();
    }

    ngOnInit() {
        // reset login status
        // this.authenticationService.logout();
    }

    ngAfterViewInit() {
        if (this.router.url == '/home/login')
        {
            this.loginformModal.open();
        }
    }

    changeTab(): void {
        this.model.isLoginMode = !this.model.isLoginMode;
        this.model.isRegisterMode = !this.model.isRegisterMode;
    }

    login() {
        this.model.isDataLoading = true;
        this.authenticationService.login(this.model.username, this.model.password)
            .subscribe(data => {
                let result = data;
                if (result.ok == true) {
                    this.model.isDataLoading = false; 
                    this.loginformModal.close();                   
                    this.router.navigate(['/home/profile']);
                } else if (result.errors) {
                    this.model.errors = result.errors;
                    this.model.isDataLoading = false;
                }
            }, error => {
                this.model.errors = error.errors;
                this.model.isDataLoading = false;
            });
    }

    register()
    {
        this.model.isDataLoading = true;
        this.authenticationService.register(this.model.regLogin, this.model.regPassword, this.model.regConfirmPassword)
            .subscribe(data => {
                let result = data;
                if (result.ok == true) {
                    this.model.isDataLoading = false;
                    this.changeTab();
                } else if (result.errors) {
                    this.model.errors = result.errors;
                    this.model.isDataLoading = false;
                }
            }, error => {
                this.model.errors = error.errors;
                this.model.isDataLoading = false;
            });
    }

    open() {
        this.loginformModal.open();
    }
}

export class LoginFormModel {
    isLoginMode: boolean;
    isRegisterMode: boolean;
    isDataLoading:boolean;
    
    username: string;
    password: string;
    errors: FormsErrors;
    regErrors: FormsErrors;

    regFirstName:string;
    regLastName: string;
    regLogin: string;
    regPassword: string;
    regConfirmPassword: string;

    constructor() {
        this.isLoginMode = false;
        this.isRegisterMode = true;
        this.isDataLoading = false;
    }
}