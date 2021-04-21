import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home';
import { MainComponent } from './main/main.component';
import { ProductsComponent } from './products/products/products.component';
import { AuthGuard } from './_helpers';
import { Role } from './_models';

const accountModule = () => import('./account/account.module').then(x => x.AccountModule);
const adminModule = () => import('./admin/admin.module').then(x => x.AdminModule);
const profileModule = () => import('./profile/profile.module').then(x => x.ProfileModule);
const productModule = () => import('./products/products.module').then(x => x.ProductsModule);

const routes: Routes = [
  { path: '', component: MainComponent},
  { path: 'test-error', component: TestErrorComponent, data: { breadcrumb: 'Test Errors' } },
  { path: 'server-error', component: ServerErrorComponent, data: { breadcrumb: 'Server Error' } },
  { path: 'not-found', component: NotFoundComponent, data: { breadcrumb: 'Not Found' } },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] , data: { breadcrumb: { skip: true } }},
  { path: 'products', loadChildren: () => import('./products/products.module').then(x => x.ProductsModule), 
      data: { breadcrumb: 'Product' }},
  { path: 'ingredients', loadChildren: () => import('./ingredient/ingredient.module').then(x => x.IngredientModule), 
      data: { breadcrumb: 'Ingredient' }},
  { path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule), data: { breadcrumb: 'Basket' } },
  { path: 'account', loadChildren: () => import('./account/account.module').then(x => x.AccountModule),  data: { breadcrumb: { skip: true } } },
  { path: 'profile', canActivate: [AuthGuard],loadChildren: () => import('./profile/profile.module').then(x => x.ProfileModule)},
  { path: 'admin', loadChildren: adminModule, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
