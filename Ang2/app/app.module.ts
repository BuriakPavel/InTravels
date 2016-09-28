import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent }  from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { PostListComponent } from './components/post-list/post-list.component';
import { PostFormComponent } from './components/post-form/post-form.component';

@NgModule({
  imports: [ BrowserModule ],
  declarations: [ AppComponent, MenuComponent, PostListComponent, PostFormComponent ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
