import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerTypeTupleCharacterComponent } from './game-designer-type-character.component';

describe('GameDesignerTypeTupleCharacterComponent', () => {
  let component: GameDesignerTypeTupleCharacterComponent;
  let fixture: ComponentFixture<GameDesignerTypeTupleCharacterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignerTypeTupleCharacterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDesignerTypeTupleCharacterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
