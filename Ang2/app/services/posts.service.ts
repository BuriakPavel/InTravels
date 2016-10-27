import { Injectable } from '@angular/core';

import { Http } from '@angular/http'
import 'rxjs/add/operator/toPromise';

import { IPost } from '../classes/post';

@Injectable()
export class PostService {

    constructor(private http : Http){}

    getPosts(): Promise<IPost[]> {
        return this.http.get('http://localhost/InTravels.WebAPI/api/PostApi')
                        .toPromise()
                        .then(res => res.json())
                        .catch(this.handleError);  
    }

    addPost(post: IPost): void {
        //posts.push(post);
    }

    private handleError(error: any): Promise<any> {
        console.log('Error!', error);
        return Promise.reject(error.message || error);
    }
}