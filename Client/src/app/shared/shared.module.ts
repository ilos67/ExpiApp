import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import {PaginationModule } from 'ngx-bootstrap/pagination';
import { PagerComponent } from './components/pager/pager.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';


@NgModule({
  declarations: [PagerComponent, PagingHeaderComponent],
  imports: [
    CommonModule,
    CarouselModule.forRoot(),
    PaginationModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ],
  exports:[
    CarouselModule,
    PaginationModule,
    PagerComponent,
    PagingHeaderComponent
  ]
})
export class SharedModule { }
