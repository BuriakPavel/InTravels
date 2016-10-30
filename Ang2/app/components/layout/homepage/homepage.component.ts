import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

import { PostService } from '../../../services/posts.service'

import { HeaderComponent } from '../../layout/header/header.component';
import { PostListComponent } from '../../entities/post/post-list/post-list.component';
import { PostFormComponent } from '../../entities/post/post-form/post-form.component';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

@Component({
    selector: 'homepage',
    templateUrl: './app/components/layout/homepage/homepage.component.html',
    providers: [PostService]
})
export class HomepageComponent implements OnInit {
    title: string;

    constructor(private router: Router) {
        this.title = "In Travels";
    }

    ngOnInit() { }

    gotoStart(): void {
        this.router.navigate(['/start']);
    }
}