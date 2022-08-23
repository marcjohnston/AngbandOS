import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../accounts/authentication/authentication.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-login-menu',
  templateUrl: './login-menu.component.html',
  styleUrls: ['./login-menu.component.css']
})
export class LoginMenuComponent implements OnInit {
  public isAuthenticated: boolean = false;
  public userName?: string | null;

  constructor(
    private _authenticationService: AuthenticationService,
  ) { }

  ngOnInit() {
    this.isAuthenticated = this._authenticationService.isAuthenticated;
    this.userName = this._authenticationService.currentUser.value?.username;
  }
}
