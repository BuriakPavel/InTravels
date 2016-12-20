import { Component, OnInit } from '@angular/core';

import { IUserProfile, UserProfile } from '../../../classes/userProfile';
import { UserService } from '../../../services/user.service';

@Component({
    moduleId: module.id,
    selector: 'userProfile',
    templateUrl: '../../entities/userProfile/userProfile.component.html',
    styleUrls: ['../../entities/userProfile/userProfile.component.css']
})

export class UserProfileComponent implements OnInit {
    userProfile: IUserProfile = new UserProfile();
    activeTab: number = 3;

    constructor(private userService: UserService) { }

    ngOnInit() {
        // get users from secure api end point
        // this.userService.getUserProfile()
        //     .subscribe(userProfile => {
        //         this.userProfile = userProfile;
        //     });
    }

    setActiveTab(index: number){
        this.activeTab = index;
    }

}