import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NatureSpellsComponent } from './nature-spells.component';

describe('NatureSpellsComponent', () => {
  let component: NatureSpellsComponent;
  let fixture: ComponentFixture<NatureSpellsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NatureSpellsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NatureSpellsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
