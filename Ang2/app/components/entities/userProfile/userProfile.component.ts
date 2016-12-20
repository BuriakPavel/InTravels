import { Component, OnInit } from '@angular/core';

import { IUserProfile, UserProfile } from '../../../classes/userProfile';
import { UserService } from '../../../services/user.service';

@Component({
    moduleId: module.id,
    selector: 'userProfile',
    templateUrl: '../../entities/userProfile/userProfile.component.html'
})

export class UserProfileComponent implements OnInit {
    userProfile: IUserProfile = new UserProfile();

    constructor(private userService: UserService) { }

    ngOnInit() {
        // get users from secure api end point
        this.userService.getUserProfile()
            .subscribe(data => {
                let result = data;
                if (result != null) {
                    this.userProfile = result;
                    console.log("profile: ", result);
                }
            }, error => { });

    }
}