import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';

@Component({
    selector: 'startpage',
    templateUrl: './app/components/layout/startpage/startpage.component.html'
})
export class StartpageComponent implements OnInit {
    constructor(private router: Router) { }

    ngOnInit() { };

    gotoHome(): void {
        this.router.navigate(['/home']);
    }
}