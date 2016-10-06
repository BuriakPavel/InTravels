import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent }  from './app.component';
import { MenuComponent } from './components/layout/menu/menu.component';
import { PostItemComponent } from './components/post/post-item/post-item.component';
import { PostListComponent } from './components/post/post-list/post-list.component';
import { PostFormComponent } from './components/post/post-form/post-form.component';

@NgModule({
  imports: [ BrowserModule ],
  declarations: [ AppComponent, MenuComponent, PostItemComponent, PostListComponent, PostFormComponent ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
