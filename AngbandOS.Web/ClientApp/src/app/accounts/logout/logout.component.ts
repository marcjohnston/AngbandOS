import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication-service/authentication.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent implements OnInit {
  public success: boolean = false;

  constructor(
    private _authenticationService: AuthenticationService
  ) { }

  ngOnInit() {
    localStorage.removeItem('keep-logged-in');
    this.success = this._authenticationService.logout();
  }
}
