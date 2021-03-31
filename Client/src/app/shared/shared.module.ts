import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import {PaginationModule } from 'ngx-bootstrap/pagination';
import { PagerComponent } from './components/pager/pager.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { CurrencyMaskModule } from 'ng2-currency-mask';


@NgModule({
  declarations: [PagerComponent, PagingHeaderComponent],
  imports: [
    CommonModule,
    CarouselModule.forRoot(),
    PaginationModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    CurrencyMaskModule
  ],
  exports:[
    CarouselModule,
    PaginationModule,
    PagerComponent,
    PagingHeaderComponent,
    CurrencyMaskModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class SharedModule { }
