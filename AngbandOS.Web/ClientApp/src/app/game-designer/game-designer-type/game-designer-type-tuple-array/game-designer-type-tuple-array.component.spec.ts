import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerTypeTupleArrayComponent } from './game-designer-type-tuple-array.component';

describe('GameDesignerTypeTupleArrayComponent', () => {
  let component: GameDesignerTypeTupleArrayComponent;
  let fixture: ComponentFixture<GameDesignerTypeTupleArrayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignerTypeTupleArrayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDesignerTypeTupleArrayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
