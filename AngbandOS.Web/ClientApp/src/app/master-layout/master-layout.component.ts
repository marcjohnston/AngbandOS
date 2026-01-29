import { Component } from '@angular/core';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';
import { ChatComponent } from '../chat/chat.component';
import { FooterComponent } from '../footer/footer.component';

@Component({
  selector: 'app-master-layout',
  imports: [
    NavMenuComponent,
    ChatComponent,
    FooterComponent
  ],
  templateUrl: './master-layout.component.html',
  styleUrl: './master-layout.component.scss',
})
export class MasterLayoutComponent {

}
