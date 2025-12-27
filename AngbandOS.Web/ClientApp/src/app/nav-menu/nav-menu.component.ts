import { Component } from '@angular/core';
import { RouterLink } from "@angular/router";
import { LoginComponent } from '../accounts/login/login.component';
import { LoginMenuComponent } from '../login-menu/login-menu.component';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss'],
  standalone: true,
  imports: [
    RouterLink,
    LoginComponent,
    LoginMenuComponent,
    NgClass
  ]
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
