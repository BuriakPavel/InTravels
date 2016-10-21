import { Component, Input, OnInit } from '@angular/core';

import { Post, IPost } from '../../../../classes/post'
import { PostItemComponent } from '../../post/post-item/post-item.component'

import { PostService } from '../../../../services/posts.service';

@Component({
    selector: 'post-list',
    templateUrl: './app/components/entities/post/post-list/post-list.component.html'
})

export class PostListComponent implements OnInit {
    posts: Post[];

    constructor(private postService: PostService){
    this.posts = [];    
    }

    ngOnInit(){
        this.postService.getPosts().then(posts => this.posts = posts); 
    }
}