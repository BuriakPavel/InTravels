import { Component, OnInit, ElementRef } from '@angular/core';

import { Router } from '@angular/router';
import { Locale, LocaleService, LocalizationService } from 'angular2localization';

@Component({
    selector: 'startpage',
    templateUrl: './app/components/layout/startpage/startpage.component.html'
})
export class StartpageComponent extends Locale implements OnInit {
    played: boolean;
    constructor(public locale: LocaleService, public localization: LocalizationService, private router: Router) {
        super(locale, localization);
        this.played = true;
    }

    ngOnInit() { };

    gotoHome(): void {
        this.router.navigate(['/home']);
    }
    
    public playStopVideo(video: any){
        this.played = !this.played;
        video.paused ? video.play() : video.pause();
    }

    public videoVolume(video: any){
        video.volume = (video.volume - 1) * -1;
    }

    public ChangeCulture(language: string, country: string) {
        this.locale.setCurrentLocale(language, country);
        //this.locale.setCurrentCurrency(currency);
    }
}