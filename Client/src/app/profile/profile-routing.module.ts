import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { ProfileDetailsComponent } from './profile-details/profile-details.component';
import { ProfileUpdateComponent } from './profile-update/profile-update.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'profile',
    pathMatch: 'full'
 },
  {
      path: '',
      children: [
          { path: '', component: ProfileDetailsComponent },
          { path: 'update', component: ProfileUpdateComponent }
      ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileRoutingModule { }
