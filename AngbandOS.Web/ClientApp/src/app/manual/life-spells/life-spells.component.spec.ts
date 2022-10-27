import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LifeSpellsComponent } from './life-spells.component';

describe('LifeSpellsComponent', () => {
  let component: LifeSpellsComponent;
  let fixture: ComponentFixture<LifeSpellsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LifeSpellsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LifeSpellsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
