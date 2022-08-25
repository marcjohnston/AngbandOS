import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorporealSpellsComponent } from './corporeal-spells.component';

describe('CorporealSpellsComponent', () => {
  let component: CorporealSpellsComponent;
  let fixture: ComponentFixture<CorporealSpellsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorporealSpellsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CorporealSpellsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
