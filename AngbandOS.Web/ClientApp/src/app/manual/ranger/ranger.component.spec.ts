import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RangerComponent } from './ranger.component';

describe('RangerComponent', () => {
  let component: RangerComponent;
  let fixture: ComponentFixture<RangerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RangerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RangerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
