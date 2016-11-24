import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {
    public token: string;
    public loginUrl: string;
    public logoutUrl: string;
    public registerUrl: string;

    constructor(private http: Http) {
        this.registerUrl = "http://localhost/InTravels.WebAPI/api/Account/Register";
        this.loginUrl = "http://localhost/InTravels.WebAPI/Token";
        this.logoutUrl = "";

        // set token if saved in local storage
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.token = currentUser && currentUser.token;
    }

    createLoginHeaders(headers: Headers) {
        headers.append('content-type', 'application/x-www-form-urlencoded');
    }

    createRegisterHeaders(headers: Headers) {
        headers.append('content-type', 'application/x-www-form-urlencoded');
    }

    register(login: string, password: string, confirmPassword: string): Observable<boolean> {
        let headers = new Headers();
        this.createRegisterHeaders(headers);
        return this.http.post(this.registerUrl, JSON.stringify({ Email: login, Password: password, ConfirmPassword: confirmPassword }),
            {
                headers: headers
            }).map((response: Response) => {
                if (response.status == 200) {
                    return true;
                } else {
                    return false;
                }
            });
    }

    login(username: string, password: string): Observable<boolean> {
         let headers = new Headers();
        this.createLoginHeaders(headers);
        return this.http.post(this.loginUrl, 
        'grant_type=password&username=' + username + '&password=' + password, 
        {
            headers: headers
        }).map((response: Response) => {
            let resJson = response.json();
            //let status = resJson.status;
            if (resJson) {
                 this.token = resJson.access_token;
                 localStorage.setItem('currentUser', JSON.stringify({
                     username: resJson.userName,
                     token: resJson.access_token
                 }));
                return true;
            } else {
                return false;
            }
        });
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('currentUser');
    }
}