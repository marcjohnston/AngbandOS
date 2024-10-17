import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerTypeTupleIntegerComponent } from './game-designer-type-integer.component';

describe('GameDesignerTypeTupleIntegerComponent', () => {
  let component: GameDesignerTypeTupleIntegerComponent;
  let fixture: ComponentFixture<GameDesignerTypeTupleIntegerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignerTypeTupleIntegerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDesignerTypeTupleIntegerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
