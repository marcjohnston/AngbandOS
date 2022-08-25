import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AbilityScoresComponent } from './ability-scores.component';

describe('AbilityScoresComponent', () => {
  let component: AbilityScoresComponent;
  let fixture: ComponentFixture<AbilityScoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AbilityScoresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AbilityScoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
