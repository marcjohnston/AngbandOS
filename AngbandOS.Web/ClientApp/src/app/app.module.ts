import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PlayComponent } from './play/play.component';
import { WatchComponent } from './watch/watch.component';

import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';

import { LoginComponent } from './accounts/login/login.component';
import { LoginMenuComponent } from './login-menu/login-menu.component';
import { ForgotPasswordDialogComponent } from './accounts/forgot-password-dialog/forgot-password-dialog.component';
import { RegistrationComponent } from './accounts/registration/registration.component';
import { AuthenticationInterceptor } from './accounts/authentication-interceptor/authentication-interceptor';
import { ProfileComponent } from './accounts/profile/profile.component';
import { LogoutComponent } from './accounts/logout/logout.component';
import { UnauthorizedInterceptorService } from './accounts/unauthorized-interceptor/unauthorized-interceptor.service';
import { AccountConfirmationComponent } from './accounts/account-confirmation/account-confirmation.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PlayComponent,
    WatchComponent,

    LoginComponent,
    RegistrationComponent,
    LoginMenuComponent,
    ForgotPasswordDialogComponent,
    ProfileComponent,
    AccountConfirmationComponent,
    LogoutComponent
  ],
  imports: [
    MatTableModule,
    MatSnackBarModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule,

    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'play', component: PlayComponent },
      { path: 'play/:guid', component: PlayComponent },
      { path: 'watch/:guid', component: WatchComponent },

      { path: 'accounts/login', component: LoginComponent },
      { path: 'accounts/logout', component: LogoutComponent },
      { path: 'accounts/profile', component: ProfileComponent },
      { path: 'accounts/confirm', component: AccountConfirmationComponent },
      { path: 'accounts/register', component: RegistrationComponent }
    ]),
    BrowserAnimationsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: UnauthorizedInterceptorService, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
