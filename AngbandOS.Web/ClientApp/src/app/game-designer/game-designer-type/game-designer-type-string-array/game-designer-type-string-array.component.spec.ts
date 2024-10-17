import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerTypeStringArrayComponent } from './game-designer-type-string-array.component';

describe('GameDesignerTypeStringArrayComponent', () => {
  let component: GameDesignerTypeStringArrayComponent;
  let fixture: ComponentFixture<GameDesignerTypeStringArrayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignerTypeStringArrayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDesignerTypeStringArrayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
