import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http'

import { PostService } from './services/posts.service';

import { AppComponent }  from './app.component';
import { MenuComponent } from './components/layout/menu/menu.component';
import { PostItemComponent } from './components/post/post-item/post-item.component';
import { PostListComponent } from './components/post/post-list/post-list.component';
import { PostFormComponent } from './components/post/post-form/post-form.component';

import { CommentItemComponent } from './components/comment/comment-item/comment-item.component';
import { CommentListComponent } from './components/comment/comment-list/comment-list.component';
import { CommentFormComponent } from './components/comment/comment-form/comment-form.component';

@NgModule({
  imports: [ BrowserModule, HttpModule ],
  declarations: [ AppComponent, MenuComponent, 
  PostItemComponent, PostListComponent, PostFormComponent,
  CommentItemComponent, CommentListComponent, CommentFormComponent
   ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
