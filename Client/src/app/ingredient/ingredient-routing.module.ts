import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IngredientComponent } from './ingredient.component';
import { IngredientDetailComponent } from './ingredient-detail/ingredient-detail.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '', 
        children: [
            { path: '', component: IngredientComponent },
            { path: ':id', component: IngredientDetailComponent ,data: {breadcrumb: {alias: 'IngredientDetails'}}}
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
export class IngredientRoutingModule { }
