import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FavourComponent } from './favour.component';

describe('FavourComponent', () => {
  let component: FavourComponent;
  let fixture: ComponentFixture<FavourComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FavourComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FavourComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
