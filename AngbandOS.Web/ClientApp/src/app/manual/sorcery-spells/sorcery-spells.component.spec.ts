import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SorcerySpellsComponent } from './sorcery-spells.component';

describe('SorcerySpellsComponent', () => {
  let component: SorcerySpellsComponent;
  let fixture: ComponentFixture<SorcerySpellsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SorcerySpellsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SorcerySpellsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
