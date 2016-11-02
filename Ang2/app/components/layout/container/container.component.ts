import { Component, OnInit } from '@angular/core';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

@Component({
    selector: 'container',
    templateUrl: './app/components/layout/container/container.component.html',
    styleUrls: ['./app/components/layout/container/container.component.css']
})
export class ContainerComponent extends Locale implements OnInit {
    constructor( public locale: LocaleService, public localization :LocalizationService) {
        super(locale, localization)
    }

    ngOnInit() { }
}