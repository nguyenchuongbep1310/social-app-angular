import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ForgotComponent } from './components/forgot/forgot.component';
import { ValidationComponent } from './components/validation/validation.component';
import { CodeComponent } from './components/code/code.component';
import { NewpasswordComponent } from './components/newpassword/newpassword.component';
import { ResetsucessComponent } from './components/resetsucess/resetsucess.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'home',
    component: DashboardComponent,
  },
  { path: 'reset-password', component: ForgotComponent },
  { path: 'email-validation', component: ValidationComponent },
  { path: 'recover-code', component: CodeComponent },
  { path: 'new-password', component: NewpasswordComponent },
  { path: 'reset-success', component: ResetsucessComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
})
export class AppRoutingModule {}
