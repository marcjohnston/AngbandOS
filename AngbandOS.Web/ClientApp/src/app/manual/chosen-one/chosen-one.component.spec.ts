import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChosenOneComponent } from './chosen-one.component';

describe('ChosenOneComponent', () => {
  let component: ChosenOneComponent;
  let fixture: ComponentFixture<ChosenOneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChosenOneComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChosenOneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
