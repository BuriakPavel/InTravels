import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

import { AuthenticationService } from '../services/authentication.service';
import { IUserProfile } from '../classes/userProfile';

@Injectable()
export class UserService {
    private getUserProfileUrl: string;

    constructor(
        private http: Http,
        private authenticationService: AuthenticationService) {

        this.getUserProfileUrl = "http://localhost/InTravels.WebAPI/api/UserProfile/GetProfile";
    }

    getUserProfile(): Observable<IUserProfile> {
        // add authorization header with jwt token
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        let headers = new Headers({
            'Authorization': 'Bearer ' + this.authenticationService.token
           
        });
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        
        // get users from api
        return this.http.post(this.getUserProfileUrl, 'Email=' + currentUser.username, {
            headers: headers
        }).map((response: Response) => {
            let resJson = response.json();
            //let status = resJson.status;
            if (resJson) {
                return resJson;
            } else {
                return;
            }
        });
    }
}