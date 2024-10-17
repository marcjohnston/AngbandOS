import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerTypeTupleForeignKeyComponent } from './game-designer-type-foreign-key.component';

describe('GameDesignerTypeTupleForeignKeyComponent', () => {
  let component: GameDesignerTypeTupleForeignKeyComponent;
  let fixture: ComponentFixture<GameDesignerTypeTupleForeignKeyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignerTypeTupleForeignKeyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDesignerTypeTupleForeignKeyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
