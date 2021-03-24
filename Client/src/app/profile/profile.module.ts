import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileDetailsComponent } from './profile-details/profile-details.component';
import { ProfileUpdateComponent } from './profile-update/profile-update.component';
import { LayoutComponent } from './layout/layout.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ProfileRoutingModule } from './profile-routing.module';



@NgModule({
  declarations: [ProfileDetailsComponent, ProfileUpdateComponent, LayoutComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ProfileRoutingModule
  ]
})
export class ProfileModule { }
