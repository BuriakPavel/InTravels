import { Component } from '@angular/core';

import { PostService } from './services/posts.service'

import { HeaderComponent } from './components/layout/header/header.component';
import { PostListComponent } from './components/entities/post/post-list/post-list.component';
import { PostFormComponent } from './components/entities/post/post-form/post-form.component';

@Component({
    selector: 'my-app',
    templateUrl: './app/app.component.html',
    providers: [PostService]
})
export class AppComponent {
    title: string;

    constructor(){
        this.title = "In Travels";
    }
}
