import { Component } from '@angular/core';
import { RouterLink } from "@angular/router";
import { LoginMenuComponent } from '../login-menu/login-menu.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss'],
  standalone: true,
  imports: [
    RouterLink,
    LoginMenuComponent,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule
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
