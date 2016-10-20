import { Component, Input } from '@angular/core';

import { Comment } from '../../../classes/comment';

@Component({
    selector: 'comment-item',
    templateUrl: './app/components/comment/comment-item/comment-item.component.html'
})
export class CommentItemComponent {
    @Input() comment: Comment;

    constructor() {
    }

    commentLike() {
        //this.comment. += 1;
    }

    commentDislike() {
        //this.comment.LikesCount -= 1;
    }
}