import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TarotSpellsComponent } from './tarot-spells.component';

describe('TarotSpellsComponent', () => {
  let component: TarotSpellsComponent;
  let fixture: ComponentFixture<TarotSpellsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TarotSpellsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TarotSpellsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
