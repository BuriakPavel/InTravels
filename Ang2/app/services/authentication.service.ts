import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/catch'
import 'rxjs/add/operator/finally'
import 'rxjs/add/observable/throw'

import { IServiceResponce, ServiceResponce, FormsErrors } from '../classes/serviseResponce';

@Injectable()
export class AuthenticationService {
    public token: string;
    //public loginUrl: string = "http://localhost/InTravels.WebAPI/Token";
    public loginUrl: string = "http://192.168.1.102/InTravels.WebAPI/Token";  
    
    public logoutUrl: string = "";
    public registerUrl: string = "http://192.168.1.102/InTravels.WebAPI/api/Account/Register";

    constructor(private http: Http) {
        // set token if saved in local storage
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.token = currentUser && currentUser.token;
    }

    createFormHeaders(headers: Headers) {
        headers.append('content-type', 'application/x-www-form-urlencoded');
    }

    register(login: string, password: string, confirmPassword: string): Observable<IServiceResponce> {
        let body: string = 'Email=' + login + '&Password='+ password +'&ConfirmPassword='+ confirmPassword;
        let headers = new Headers();
        this.createFormHeaders(headers);
        return this.http.post(this.registerUrl, body,
            {
                headers: headers
            }).map((res: Response) => {
                let resJson = res.json();
                if (resJson == "ok") {
                    return new ServiceResponce(true, null);
                } else if(resJson.errors){
                    return new ServiceResponce(false, resJson.errors);
                }
            }).catch(this.handleError);
    }

    login(username: string, password: string): Observable<IServiceResponce> {
        let body = 'grant_type=password&username=' + username + '&password=' + password;
        let headers = new Headers();
        this.createFormHeaders(headers);

        return this.http.post(this.loginUrl, body, 
        {
            headers: headers
        }).map((res: Response) => {
            let resJson = res.json();
            if (resJson) {
                 this.token = resJson.access_token;
                 localStorage.setItem('currentUser', JSON.stringify({
                     username: resJson.userName,
                     token: resJson.access_token
                 }));
                return new ServiceResponce(true, null);
            } else {
                return new ServiceResponce(false, resJson.errors);
            }
        }).catch(this.handleError);
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('currentUser');
    }

    handleError(error: any): Observable<IServiceResponce> {
        console.log("authentication.service error", error.json());
        return Observable.throw(new ServiceResponce(false, error.json().error_description));
    }
}