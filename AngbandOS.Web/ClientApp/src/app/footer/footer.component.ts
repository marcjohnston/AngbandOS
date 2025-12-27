import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css'],
  standalone: true
})
export class FooterComponent implements OnInit {
  public year: number | null = null;
  constructor() { }

  ngOnInit(): void {
    this.year = (new Date()).getFullYear();
  }
}
