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
import { AuthGuardService as AuthGuard } from 'src/_services/auth.guard';
import { WallComponent } from './components/wall/wall.component';
import { ImageComponent } from './components/image/image.component';
import { SearchUserComponent } from './components/search-user/search-user.component';
import { NavComponent } from './components/nav/nav.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'home',
    component: DashboardComponent,
    canActivate: [AuthGuard],

  },
  { path: 'reset-password', component: ForgotComponent },
  { path: 'email-validation', component: ValidationComponent },
  { path: 'recover-code', component: CodeComponent },
  { path: 'new-password', component: NewpasswordComponent },
  { path: 'reset-success', component: ResetsucessComponent },
  { path: 'personal-wall', component: WallComponent, canActivate: [AuthGuard] },
  { path: 'image', component: ImageComponent },
  { path: 'search-user', component: SearchUserComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
];

@NgModule({
  declarations: [
  ],
  imports: [RouterModule.forRoot(routes)],
})
export class AppRoutingModule {}
