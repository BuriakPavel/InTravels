import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

@Component({
    selector: 'notFoundPage',
    templateUrl: './app/components/layout/notFoundPage/notFoundPage.component.html'
})
export class NotFoundPageComponent implements OnInit {
    constructor(private router: Router) { }

    ngOnInit() { }

    gotoStart() {
        this.router.navigate(['/start']);
    }
    gotoHome() {
        this.router.navigate(['/home']);
    }
}