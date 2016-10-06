import { Injectable } from '@angular/core';

import { IPost } from '../classes/post';
import { posts } from '../data/posts.data';

@Injectable()
export class PostService {
    getPosts(): IPost[] {
        return posts;
    }
}