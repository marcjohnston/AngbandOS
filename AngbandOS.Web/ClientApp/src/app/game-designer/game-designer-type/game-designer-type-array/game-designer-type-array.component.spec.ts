import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerTypeArrayComponent } from './game-designer-type-array.component';

describe('GameDesignerTypeArrayComponent', () => {
  let component: GameDesignerTypeArrayComponent;
  let fixture: ComponentFixture<GameDesignerTypeArrayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignerTypeArrayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDesignerTypeArrayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
