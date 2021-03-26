import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products/products.component';
import { Router, RouterModule, Routes } from '@angular/router';
import { ProductDetailComponent } from './product-detail/product-detail.component';
const routes: Routes = [
  {
    path: '',
    redirectTo: 'products',
    pathMatch: 'full'
 },
  {
      path: '', 
      children: [
          { path: '', component: ProductsComponent },
          { path: 'products/:id', component: ProductDetailComponent }
      ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class ProductsRoutingModule { }
