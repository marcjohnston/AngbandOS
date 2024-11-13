import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerTypeColorComponent } from './game-designer-type-color.component';

describe('GameDesignerTypeColorComponent', () => {
  let component: GameDesignerTypeColorComponent;
  let fixture: ComponentFixture<GameDesignerTypeColorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignerTypeColorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDesignerTypeColorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
