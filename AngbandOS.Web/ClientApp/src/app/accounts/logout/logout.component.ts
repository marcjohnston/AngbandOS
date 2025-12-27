import { Component, NgZone, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication-service/authentication.service';
import { Router } from '@angular/router';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss'],
  standalone: true,
  imports: [
    NgIf
  ]
})
export class LogoutComponent implements OnInit {
  public success: boolean = false;

  constructor(
    private _authenticationService: AuthenticationService,
    private _router: Router,
    private _zone: NgZone
  ) { }

  ngOnInit() {
    localStorage.removeItem('keep-logged-in');
    this.success = this._authenticationService.logout();
    this._zone.run(() => this._router.navigate(['/']));
  }
}
