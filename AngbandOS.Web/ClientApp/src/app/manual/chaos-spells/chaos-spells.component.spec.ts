import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChaosSpellsComponent } from './chaos-spells.component';

describe('ChaosSpellsComponent', () => {
  let component: ChaosSpellsComponent;
  let fixture: ComponentFixture<ChaosSpellsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChaosSpellsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChaosSpellsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
