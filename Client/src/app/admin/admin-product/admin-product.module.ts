import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditProductComponent } from './edit-product/edit-product.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AdminComponent } from './admin.component';
import { AdminProductRoutingModule } from './admin-product-routing.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [EditProductComponent, AdminComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule,
    AdminProductRoutingModule
  ]
})
export class AdminProductModule { }
