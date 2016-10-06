import { Component } from '@angular/core';

import { MenuComponent } from './components/layout/menu/menu.component';
import { PostListComponent } from './components/post/post-list/post-list.component';
import { PostFormComponent } from './components/post/post-form/post-form.component';

import { Post } from '../app/classes/post';

@Component({
    selector: 'my-app',
    templateUrl: './app/app.component.html'
})
export class AppComponent {
    title: string;
    posts: Post[];

    constructor(){
        this.title = "InTravels";
        this.posts = [ 
            new Post("post title 1", "post text 1", "username 1"),
            new Post("post title 2", "post text 2", "username 2"),
            new Post("post title 3", "post text 3", "username 3")
            ];        
    }
}
