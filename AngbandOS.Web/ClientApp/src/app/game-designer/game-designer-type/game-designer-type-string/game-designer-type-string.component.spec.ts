import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerTypeStringComponent } from './game-designer-type-string.component';

describe('GameDesignerTypeStringComponent', () => {
  let component: GameDesignerTypeStringComponent;
  let fixture: ComponentFixture<GameDesignerTypeStringComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignerTypeStringComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDesignerTypeStringComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
