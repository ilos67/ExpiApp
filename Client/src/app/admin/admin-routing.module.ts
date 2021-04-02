import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { OverviewComponent } from './overview/overview.component';
import { SubnavComponent } from './subnav/subnav.component';
import { EditProductComponent } from './admin-product/edit-product/edit-product.component';

const accountsModule = () => import('./accounts/accounts.module').then(x => x.AccountsModule);
const adminProductModule = () => import('./admin-product/admin-product.module').then(x => x.AdminProductModule);

const routes: Routes = [
    { path: '', component: SubnavComponent, outlet: 'subnav' },
    {
        path: '', component: LayoutComponent,
        children: [
            { path: '', component: OverviewComponent },
            { path: 'accounts', loadChildren: accountsModule },
            { path: 'product-management', loadChildren: adminProductModule },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AdminRoutingModule { }
