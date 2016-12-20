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
    private getUserProfileUrl: string = "http://10.214.3.13/InTravels.WebAPI/api/UserProfile/GetProfile";

    constructor(
        private http: Http,
        private authenticationService: AuthenticationService) {
    }

    getUserProfile(): Observable<IUserProfile> {
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        let headers = new Headers({
            'Authorization': 'Bearer ' + currentUser.token
        });
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        
        let body: string = 'Email=' + currentUser.username; 

        return this.http.post(this.getUserProfileUrl, body, {
            headers: headers
        }).map((res: Response) => {
             if (res.ok == true){
                var result = res.json()
                return result;
             }
        }).catch(this.handleError);
    }

    handleError(error: any): Observable<any> {
        console.log("user.service error", error);
        return Observable.throw(error.message || error);
    }

}