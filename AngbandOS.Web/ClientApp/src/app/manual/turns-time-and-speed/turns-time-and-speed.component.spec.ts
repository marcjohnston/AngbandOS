import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurnsTimeAndSpeedComponent } from './turns-time-and-speed.component';

describe('TurnsTimeAndSpeedComponent', () => {
  let component: TurnsTimeAndSpeedComponent;
  let fixture: ComponentFixture<TurnsTimeAndSpeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TurnsTimeAndSpeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TurnsTimeAndSpeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
