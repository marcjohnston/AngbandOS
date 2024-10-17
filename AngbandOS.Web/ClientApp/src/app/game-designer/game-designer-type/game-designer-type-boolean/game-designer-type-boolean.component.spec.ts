import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerTypeBooleanComponent } from './game-designer-type-boolean.component';

describe('GameDesignerTypeBooleanComponent', () => {
  let component: GameDesignerTypeBooleanComponent;
  let fixture: ComponentFixture<GameDesignerTypeBooleanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignerTypeBooleanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDesignerTypeBooleanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
