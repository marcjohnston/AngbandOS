import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FolkSpellsComponent } from './folk-spells.component';

describe('FolkSpellsComponent', () => {
  let component: FolkSpellsComponent;
  let fixture: ComponentFixture<FolkSpellsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FolkSpellsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FolkSpellsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
