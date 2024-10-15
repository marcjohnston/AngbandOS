import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerTypeComponent } from './game-designer-type.component';

describe('GameDesignerTypeComponent', () => {
  let component: GameDesignerTypeComponent;
  let fixture: ComponentFixture<GameDesignerTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignerTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDesignerTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
