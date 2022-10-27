import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FanaticComponent } from './fanatic.component';

describe('FanaticComponent', () => {
  let component: FanaticComponent;
  let fixture: ComponentFixture<FanaticComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FanaticComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FanaticComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
