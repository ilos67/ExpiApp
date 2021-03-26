import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { appInitializer, ErrorInterceptor, JwtInterceptor } from './_helpers';
import { AlertComponent } from './_components/alert.component';
import { HomeComponent } from './home/home.component';
import { MainModule } from './main/main.module';
import { AccountService } from './_services/account.service';

@NgModule({
  declarations: [
    AppComponent,
    AlertComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MainModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    { provide: APP_INITIALIZER, useFactory: appInitializer, multi: true, deps: [AccountService] },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
