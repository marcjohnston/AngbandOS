import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GreatOnesComponent } from './great-ones.component';

describe('GreatOnesComponent', () => {
  let component: GreatOnesComponent;
  let fixture: ComponentFixture<GreatOnesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GreatOnesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GreatOnesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
