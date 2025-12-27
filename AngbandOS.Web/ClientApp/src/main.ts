import { enableProdMode, importProvidersFrom } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';

import { AppComponent } from './app/app.component';
import { environment } from './environments/environment';

// Components for routes
import { HomeComponent } from './app/home/home.component';
import { PlayComponent } from './app/play/play.component';
import { WatchComponent } from './app/watch/watch.component';
import { MessagesWindowComponent } from './app/messages-window/messages-window.component';
import { UiComponent } from './app/ui/ui.component';
import { DashboardComponent } from './app/dashboard/dashboard.component';
import { GameDesignerComponent } from './app/game-designer/game-designer.component';

// Account components
import { LoginComponent } from './app/accounts/login/login.component';
import { LogoutComponent } from './app/accounts/logout/logout.component';
import { ProfileComponent } from './app/accounts/profile/profile.component';
import { AccountConfirmationComponent } from './app/accounts/account-confirmation/account-confirmation.component';
import { RegistrationComponent } from './app/accounts/registration/registration.component';
import { ForgotPasswordComponent } from './app/accounts/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './app/accounts/reset-password/reset-password.component';
import { ChangePasswordComponent } from './app/accounts/change-password/change-password.component';

// Services / interceptors / guards
import { UnauthorizedInterceptorService } from './app/accounts/unauthorized-interceptor/unauthorized-interceptor.service';
import { AuthenticationInterceptor } from './app/accounts/authentication-interceptor/authentication-interceptor';
import { CanDeactivatePlay } from './app/can-deactivate-play/can-deactivate-play';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  importProvidersFrom(BrowserAnimationsModule),
  provideRouter([
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'play', component: PlayComponent, canDeactivate: [CanDeactivatePlay] },
    { path: 'play/:guid', component: PlayComponent, canDeactivate: [CanDeactivatePlay] },
    { path: 'watch/:guid', component: WatchComponent },
    { path: 'watch/:guid/messages', component: MessagesWindowComponent },
    { path: 'ui', component: UiComponent },
    { path: 'game-designer', component: GameDesignerComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'accounts/login', component: LoginComponent },
    { path: 'accounts/logout', component: LogoutComponent },
    { path: 'accounts/profile', component: ProfileComponent },
    { path: 'accounts/confirm', component: AccountConfirmationComponent },
    { path: 'accounts/register', component: RegistrationComponent },
    { path: 'accounts/forgot-password', component: ForgotPasswordComponent },
    { path: 'accounts/reset-password', component: ResetPasswordComponent },
    { path: 'accounts/change-password', component: ChangePasswordComponent }
  ]),
  provideHttpClient(withInterceptorsFromDi()),
  CanDeactivatePlay,
  UnauthorizedInterceptorService,
  AuthenticationInterceptor
];

if (environment.production) {
  enableProdMode();
}

bootstrapApplication(AppComponent, { providers })
  .catch(err => console.error(err));
