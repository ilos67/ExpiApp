import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products/products.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductsRoutingModule } from './products-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [ProductsComponent, ProductDetailComponent, ProductItemComponent, ProductListComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ProductsRoutingModule,
    SharedModule
  ],
  exports:[ProductItemComponent, ProductsComponent]
})
export class ProductsModule { }
