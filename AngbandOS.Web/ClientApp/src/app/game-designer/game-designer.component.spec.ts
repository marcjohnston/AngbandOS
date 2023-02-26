import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerComponent } from './game-designer.component';

describe('GameDesignerComponent', () => {
  let component: GameDesignerComponent;
  let fixture: ComponentFixture<GameDesignerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDesignerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
