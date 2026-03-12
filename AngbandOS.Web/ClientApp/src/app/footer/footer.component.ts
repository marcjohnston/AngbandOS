import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss'],
  standalone: true
})
export class FooterComponent implements OnInit {
  public year: number | null = null;
  public readonly version = environment.version.replace('v', '');
  constructor() { }

  ngOnInit(): void {
    this.year = (new Date()).getFullYear();
  }
}
