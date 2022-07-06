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
import { LayoutComponent } from './components/layout/layout.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: '',
    canActivate: [AuthGuard],
    component: LayoutComponent,
    children: [{
      path: 'home',
      component: DashboardComponent,
    },
    { path: 'personal-wall', component: WallComponent },
    ]
  },

  { path: 'reset-password', component: ForgotComponent },
  { path: 'email-validation', component: ValidationComponent },
  { path: 'recover-code', component: CodeComponent },
  { path: 'new-password', component: NewpasswordComponent },
  { path: 'reset-success', component: ResetsucessComponent },
  { path: 'image', component: ImageComponent },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
})
export class AppRoutingModule { }
