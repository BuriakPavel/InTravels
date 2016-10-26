// modules
import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from '../app/app-routing.module';

// services
import { PostService } from './services/posts.service';

// layout components
import { HeaderComponent } from './components/layout/header/header.component';
import { LeftbarComponent } from './components/layout/leftbar/leftbar.component';
import { ContainerComponent } from './components/layout/container/container.component';
import { RightbarComponent } from './components/layout/rightbar/rightbar.component';
import { FooterComponent } from './components/layout/mainfooter/mainfooter.component';

// pages
import { StartpageComponent } from './components/layout/startpage/startpage.component'
import { HomepageComponent } from './components/layout/homepage/homepage.component'
import { NotFoundPageComponent } from './components/layout/notFoundPage/notFoundPage.component';

// entities components
import { AppComponent }  from './app.component';
import { PostItemComponent } from './components/entities/post/post-item/post-item.component';
import { PostListComponent } from './components/entities/post/post-list/post-list.component';
import { PostFormComponent } from './components/entities/post/post-form/post-form.component';
import { CommentItemComponent } from './components/entities/comment/comment-item/comment-item.component';
import { CommentListComponent } from './components/entities/comment/comment-list/comment-list.component';
import { CommentFormComponent } from './components/entities/comment/comment-form/comment-form.component';


@NgModule({
  imports: [ 
    BrowserModule, 
    HttpModule,
    AppRoutingModule
    ],
  declarations: [ 
    AppComponent, 
    StartpageComponent, HomepageComponent, NotFoundPageComponent, 
    HeaderComponent, LeftbarComponent, ContainerComponent, RightbarComponent, FooterComponent,
    PostItemComponent, PostListComponent, PostFormComponent,
    CommentItemComponent, CommentListComponent, CommentFormComponent
   ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
