import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { StartpageComponent }      from '../app/components/layout/startpage/startpage.component';
import { HomepageComponent }  from '../app/components/layout/homepage/homepage.component';

const routes: Routes = [
  { path: '', redirectTo: '/start', pathMatch: 'full' },
  { path: 'start',  component: StartpageComponent },
  { path: 'home', component: HomepageComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
