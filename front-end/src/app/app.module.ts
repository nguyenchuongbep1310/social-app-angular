import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavComponent } from './components/nav/nav.component';
import { ForgotComponent } from './components/forgot/forgot.component';
import { ValidationComponent } from './components/validation/validation.component';
import { CodeComponent } from './components/code/code.component';
import { NewpasswordComponent } from './components/newpassword/newpassword.component';
import { ResetsucessComponent } from './components/resetsucess/resetsucess.component';
import { WallComponent } from './components/wall/wall.component';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    DashboardComponent,
    NavComponent,
    ForgotComponent,
    ValidationComponent,
    CodeComponent,
    NewpasswordComponent,
    ResetsucessComponent,
    WallComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
