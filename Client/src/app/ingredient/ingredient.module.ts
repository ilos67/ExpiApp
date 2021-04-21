import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IngredientComponent } from './ingredient.component';
import { IngredientItemComponent } from './ingredient-item/ingredient-item.component';
import { IngredientDetailComponent } from './ingredient-detail/ingredient-detail.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { IngredientRoutingModule } from './ingredient-routing.module';



@NgModule({
  declarations: [IngredientComponent, IngredientItemComponent, IngredientDetailComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    IngredientRoutingModule,
    SharedModule
  ],
  exports:[IngredientComponent, IngredientItemComponent]
})
export class IngredientModule { }
