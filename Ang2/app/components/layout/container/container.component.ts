import { Component, OnInit } from '@angular/core';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

@Component({
    selector: 'container',
    templateUrl: './app/components/layout/container/container.component.html',
    styleUrls: ['./app/components/layout/container/container.component.css']
})

export class ContainerComponent extends Locale implements OnInit {
    element: any;
    ny: number = 0;
    rotINT: number;
    rotYINT: number;

    constructor(public locale: LocaleService, public localization: LocalizationService) {
        super(locale, localization)
        this.element = null;
        this.rotYINT = 0;
    }

    ngOnInit() { }

    rotateYDIV(element: any) {
        clearInterval(this.rotYINT)
        //this.rotYINT = setInterval(this.startYRotate(element), 1000)
        function timeout() {
            setTimeout(function () {
                // Do Something Here
                // Then recall the parent function to
                // create a recursive loop.
                this.startYRotate(element)
                timeout();
            }, 1000);
        }
    }

    startYRotate(element: any) {
        while (this.ny < 320) {
            this.ny += 1;
            element.style.transform = "rotateY(" + this.ny + "deg)"
            element.style.webkitTransform = "rotateY(" + this.ny + "deg)"
            element.style.OTransform = "rotateY(" + this.ny + "deg)"
            element.style.MozTransform = "rotateY(" + this.ny + "deg)"
        }
    }
}