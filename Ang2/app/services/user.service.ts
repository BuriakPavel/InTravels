import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/catch'
import 'rxjs/add/observable/throw'

import { AuthenticationService } from '../services/authentication.service';
import { IUserProfile } from '../classes/userProfile';

@Injectable()
export class UserService {
    private getUserProfileUrl: string = "http://192.168.1.102/InTravels.WebAPI/api/UserProfile/GetProfile";

    constructor(
        private http: Http,
        private authenticationService: AuthenticationService) {
    }

    getUserProfile(): Observable<IUserProfile> {
        // add authorization header with jwt token
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        let headers = new Headers({
            'Authorization': 'Bearer ' + this.authenticationService.token
        });
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        
        let body: string = 'Email=' + currentUser.username; 

        // get users from api
        return this.http.post(this.getUserProfileUrl, body, {
            headers: headers
        }).map(response => response.json())
        .catch(this.handleError);
    }

    handleError(error: any): Observable<any> {
        console.log("user.service error", error);
        return Observable.throw(error.message || error);
    }

}