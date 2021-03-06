import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditProductComponent } from './edit-product/edit-product.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AdminComponent } from './admin.component';
import { AdminProductRoutingModule } from './admin-product-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductFormComponent } from './product-form/product-form.component';
import { EditProductPhotosComponent } from './edit-product-photos/edit-product-photos.component';
import { EditIngredientComponent } from './edit-ingredient/edit-ingredient.component';
import { IngredientItemComponent } from 'src/app/ingredient/ingredient-item/ingredient-item.component';
import { IngredientModule } from 'src/app/ingredient/ingredient.module';



@NgModule({
  declarations: [EditProductComponent, AdminComponent, ProductFormComponent, EditProductPhotosComponent, EditIngredientComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule,
    AdminProductRoutingModule,
    IngredientModule
  ],
  exports:[]
})
export class AdminProductModule { }
