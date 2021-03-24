import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-bootstrap/carousel';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CarouselModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ],
  exports:[
    CarouselModule
  ]
})
export class SharedModule { }
