import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

import { PostService } from '../../../services/posts.service'
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

import { HeaderComponent } from '../../layout/header/header.component';
import { PostListComponent } from '../../entities/post/post-list/post-list.component';
import { PostFormComponent } from '../../entities/post/post-form/post-form.component';

@Component({
    selector: 'homepage',
    templateUrl: './app/components/layout/homepage/homepage.component.html',
    providers: [PostService]
})
export class HomepageComponent extends Locale implements OnInit {
    constructor(
        public locale: LocaleService, 
        public localization :LocalizationService, 
        private router: Router) {
            super(locale, localization);
    }

    ngOnInit() { }

    gotoStart(): void {
        this.router.navigate(['/start']);
    }
}