import { Component, Output, EventEmitter } from '@angular/core';
import { Post } from '../../../../classes/post';
import { PostService } from '../../../../services/posts.service';

@Component({
    selector: 'post-form',
    templateUrl: './app/components/entities/post/post-form/post-form.component.html'
})
export class PostFormComponent {
    @Output() added = new EventEmitter();

    constructor(private postService: PostService){}

    add(title: string, text: string, user: string) : void{
        let newPost = new Post(title, text, user);
        this.postService.addPost(newPost);
    }  
}