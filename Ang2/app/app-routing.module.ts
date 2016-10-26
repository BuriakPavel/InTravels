import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { StartpageComponent }      from '../app/components/layout/startpage/startpage.component';
import { HomepageComponent }  from '../app/components/layout/homepage/homepage.component';
import { NotFoundPageComponent } from '../app/components/layout/notFoundPage/notFoundPage.component';

import { ContainerComponent } from '../app/components/layout/container/container.component';

import { PostListComponent } from '../app/components/entities/post/post-list/post-list.component';
import { PostFormComponent } from '../app/components/entities/post/post-form/post-form.component';

const routes: Routes = [
  { path: '', redirectTo: '/start', pathMatch: 'full' },
  { path: 'start', component: StartpageComponent },
  {
    path: 'home', component: HomepageComponent,
    children: [
      { path: '', redirectTo: 'index', pathMatch: 'full' },
      { path: 'index', component: ContainerComponent },
      { path: 'posts', component: PostListComponent },
      { path: 'postnew', component: PostFormComponent }
    ]
  },
  { path: '**', component: NotFoundPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
