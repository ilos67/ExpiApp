import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { LayoutComponent } from './layout/layout.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { VerifyEmailComponent } from './verify-email/verify-email.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AccountRoutingModule } from './account-routing.module';



@NgModule({
  declarations: [ForgotPasswordComponent, LayoutComponent, LoginComponent, RegisterComponent, ResetPasswordComponent, VerifyEmailComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AccountRoutingModule
  ]
})
export class AccountModule { }
