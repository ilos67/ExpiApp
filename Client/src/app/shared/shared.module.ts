import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import {PaginationModule } from 'ngx-bootstrap/pagination';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown'
import {TabsModule } from 'ngx-bootstrap/tabs';
import {NgxGalleryModule} from '@kolkov/ngx-gallery';
import { PagerComponent } from './components/pager/pager.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { PhotoWidgetComponent } from './components/photo-widget/photo-widget.component';
import {ImageCropperModule} from 'ngx-image-cropper';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { BasketSummaryComponent } from './components/basket-summary/basket-summary.component';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';

@NgModule({
  declarations: [PagerComponent, PagingHeaderComponent, PhotoWidgetComponent, BasketSummaryComponent, OrderTotalsComponent],
  imports: [
    CommonModule,
    CarouselModule.forRoot(),
    PaginationModule.forRoot(),
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    NgxDropzoneModule,
    ImageCropperModule,
    NgxGalleryModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    CurrencyMaskModule
  ],
  exports:[
    CarouselModule,
    PaginationModule,
    NgxGalleryModule,
    BsDropdownModule,
    NgxDropzoneModule,
    ImageCropperModule,
    PagerComponent,
    PagingHeaderComponent,
    CurrencyMaskModule,
    ReactiveFormsModule,
    FormsModule,
    TabsModule,
    PhotoWidgetComponent,
    BasketSummaryComponent,
    OrderTotalsComponent
  ]
})
export class SharedModule { }
