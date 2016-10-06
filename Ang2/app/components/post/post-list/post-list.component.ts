import { Component, Input } from '@angular/core';
import { PostItemComponent } from '../../post/post-item/post-item.component'
import { Post } from '../../../classes/post'

@Component({
    selector: 'post-list',
    templateUrl: './app/components/post/post-list/post-list.component.html'
})

export class PostListComponent {
    @Input() posts: Post[];
}