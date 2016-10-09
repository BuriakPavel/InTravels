import { Component } from '@angular/core';

import { PostService } from './services/posts.service'

import { MenuComponent } from './components/layout/menu/menu.component';
import { PostListComponent } from './components/post/post-list/post-list.component';
import { PostFormComponent } from './components/post/post-form/post-form.component';

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
