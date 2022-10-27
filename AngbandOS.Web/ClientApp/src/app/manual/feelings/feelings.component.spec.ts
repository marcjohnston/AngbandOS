import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeelingsComponent } from './feelings.component';

describe('FeelingsComponent', () => {
  let component: FeelingsComponent;
  let fixture: ComponentFixture<FeelingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FeelingsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FeelingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
