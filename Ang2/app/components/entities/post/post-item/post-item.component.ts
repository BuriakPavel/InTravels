import { Component, Input, Output, EventEmitter } from '@angular/core';

import { Post } from '../../../../classes/post';

@Component({
    selector: 'post-item',
    templateUrl: './app/components/entities/post/post-item/post-item.component.html'
})
export class PostItemComponent {
    @Input() post: Post;
    @Output() deleted: EventEmitter<Post>;

    constructor() {
        this.deleted = new EventEmitter<Post>();
    }

    postLike() {
        this.post.LikesCount += 1;
    }

    postDislike() {
        this.post.LikesCount -= 1;
    }

    delete() {
        this.deleted.emit(this.post);
    }
}