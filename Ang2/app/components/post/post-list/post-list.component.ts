import { Component, Input, OnInit } from '@angular/core';

import { Post } from '../../../classes/post'
import { PostItemComponent } from '../../post/post-item/post-item.component'

import { PostService } from '../../../services/posts.service';

@Component({
    selector: 'post-list',
    templateUrl: './app/components/post/post-list/post-list.component.html',
    providers: [PostService]
})

export class PostListComponent implements OnInit {
    posts: Post[];

    constructor(private postService: PostService){
        this.posts = [];
        console.log("Done");   
    }

    ngOnInit(){
        this.posts = this.postService.getPosts(); 
        console.log("OnInit");
    }
}