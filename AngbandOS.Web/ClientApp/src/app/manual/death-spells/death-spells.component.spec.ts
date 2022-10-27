import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeathSpellsComponent } from './death-spells.component';

describe('DeathSpellsComponent', () => {
  let component: DeathSpellsComponent;
  let fixture: ComponentFixture<DeathSpellsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeathSpellsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeathSpellsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
