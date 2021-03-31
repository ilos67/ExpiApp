import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { EditProductComponent } from './edit-product/edit-product.component';


const routes: Routes = [
  {path: '', component: AdminComponent},
  {path: 'create', component: EditProductComponent},
  {path: 'edit/:id', component: EditProductComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AdminProductRoutingModule { }
