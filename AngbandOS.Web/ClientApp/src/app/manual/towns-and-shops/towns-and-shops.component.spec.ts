import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TownsAndShopsComponent } from './towns-and-shops.component';

describe('TownsAndShopsComponent', () => {
  let component: TownsAndShopsComponent;
  let fixture: ComponentFixture<TownsAndShopsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TownsAndShopsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TownsAndShopsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
