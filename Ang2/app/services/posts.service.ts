import { Injectable } from '@angular/core';

import { Http } from '@angular/http'
import 'rxjs/add/operator/toPromise';

import { IPost } from '../classes/post';
import { posts } from '../data/posts.data';

@Injectable()
export class PostService {

    constructor(private http : Http){}

    getPosts(): Promise<IPost[]> {
        return this.http.get('app/data/posts.json')
                        .toPromise()
                        .then(res => res.json())
                        .catch(this.handleError); 
    }

    addPost(post: IPost): void {
        posts.push(post);
    }

    private handleError(error: any): Promise<any> {
        console.log('Error!', error);
        return Promise.reject(error.message || error);
    }
}