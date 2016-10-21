import { Component, Input, OnInit } from '@angular/core';

import { Comment, IComment } from '../../../../classes/comment'
import { CommentItemComponent } from '../../comment/comment-item/comment-item.component'

@Component({
    selector: 'comment-list',
    templateUrl: './app/components/entities/comment/comment-list/comment-list.component.html'
})

export class CommentListComponent {
    @Input() comments: Comment[];

    constructor(){
    }
}