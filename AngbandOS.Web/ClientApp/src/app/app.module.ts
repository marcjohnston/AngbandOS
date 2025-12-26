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
import { UiComponent } from './ui/ui.component';

import { ColorPickerModule } from 'ngx-color-picker';

import { MatLegacySnackBarModule as MatSnackBarModule } from '@angular/material/legacy-snack-bar';
import { MatLegacyTableModule as MatTableModule } from '@angular/material/legacy-table';
import { MatLegacyCheckboxModule as MatCheckboxModule } from '@angular/material/legacy-checkbox';
import { MatLegacyFormFieldModule as MatFormFieldModule } from '@angular/material/legacy-form-field';
import { MatLegacyDialogModule as MatDialogModule } from '@angular/material/legacy-dialog';
import { MatLegacyInputModule as MatInputModule } from '@angular/material/legacy-input';
import { MatLegacyButtonModule as MatButtonModule } from '@angular/material/legacy-button';
import { MatLegacySliderModule as MatSliderModule } from '@angular/material/legacy-slider';
import { MatIconModule } from '@angular/material/icon';
import { MatLegacyCardModule as MatCardModule } from '@angular/material/legacy-card';
import { MatLegacySelectModule as MatSelectModule } from '@angular/material/legacy-select';
import { DragDropModule } from '@angular/cdk/drag-drop';

import { ResetPasswordComponent } from './accounts/reset-password/reset-password.component';
import { LoginComponent } from './accounts/login/login.component';
import { LoginMenuComponent } from './login-menu/login-menu.component';
import { ForgotPasswordComponent } from './accounts/forgot-password/forgot-password.component';
import { RegistrationComponent } from './accounts/registration/registration.component';
import { AuthenticationInterceptor } from './accounts/authentication-interceptor/authentication-interceptor';
import { ProfileComponent } from './accounts/profile/profile.component';
import { LogoutComponent } from './accounts/logout/logout.component';
import { UnauthorizedInterceptorService } from './accounts/unauthorized-interceptor/unauthorized-interceptor.service';
import { AccountConfirmationComponent } from './accounts/account-confirmation/account-confirmation.component';
import { ChangePasswordComponent } from './accounts/change-password/change-password.component';

import { ChatComponent } from './chat/chat.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PreferencesDialogComponent } from './preferences-dialog/preferences-dialog.component';
import { GameDesignerComponent } from './game-designer/game-designer.component';
import { CanDeactivatePlay } from './can-deactivate-play/can-deactivate-play';
import { MessagesWindowComponent } from './messages-window/messages-window.component';
import { FooterComponent } from './footer/footer.component';
import { GameDesignerPropertyComponent } from './game-designer/game-designer-property/game-designer-property.component';
import { GameDesignerTypeComponent } from './game-designer/game-designer-type/game-designer-type.component';
import { GameDesignerTypeBooleanComponent } from './game-designer/game-designer-type/game-designer-type-boolean/game-designer-type-boolean.component';
import { GameDesignerTypeStringArrayComponent } from './game-designer/game-designer-type/game-designer-type-string-array/game-designer-type-string-array.component';
import { GameDesignerTypeStringComponent } from './game-designer/game-designer-type/game-designer-type-string/game-designer-type-string.component';
import { GameDesignerTypeTupleArrayComponent } from './game-designer/game-designer-type/game-designer-type-tuple-array/game-designer-type-tuple-array.component';
import { GameDesignerTypeIntegerComponent } from './game-designer/game-designer-type/game-designer-type-integer/game-designer-type-integer.component';
import { GameDesignerTypeCharacterComponent } from './game-designer/game-designer-type/game-designer-type-character/game-designer-type-character.component';
import { GameDesignerTypeForeignKeyComponent } from './game-designer/game-designer-type/game-designer-type-foreign-key/game-designer-type-foreign-key.component';
import { GameDesignerTypeColorComponent } from './game-designer/game-designer-type/game-designer-type-color/game-designer-type-color.component';

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
    ForgotPasswordComponent,
    ProfileComponent,
    AccountConfirmationComponent,
    LogoutComponent,
    ResetPasswordComponent,
    ChangePasswordComponent,

    UiComponent,
    ChatComponent,
    DashboardComponent,
    PreferencesDialogComponent,
    GameDesignerComponent,
    MessagesWindowComponent,
    FooterComponent,
    GameDesignerPropertyComponent,
    GameDesignerTypeComponent,
    GameDesignerTypeBooleanComponent,
    GameDesignerTypeStringArrayComponent,
    GameDesignerTypeStringComponent,
    GameDesignerTypeTupleArrayComponent,
    GameDesignerTypeIntegerComponent,
    GameDesignerTypeCharacterComponent,
    GameDesignerTypeForeignKeyComponent,
    GameDesignerTypeColorComponent,
  ],
  imports: [
    MatTableModule,
    MatSnackBarModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    MatSliderModule,
    MatIconModule,
    MatCardModule,
    DragDropModule,
    MatSelectModule,

    ColorPickerModule,

    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
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
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: UnauthorizedInterceptorService, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true },
    CanDeactivatePlay
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
