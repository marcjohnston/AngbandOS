import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerPropertyEntityComponent } from './game-designer-property-entity.component';

describe('GameDesignerPropertyEntityComponent', () => {
  let component: GameDesignerPropertyEntityComponent;
  let fixture: ComponentFixture<GameDesignerPropertyEntityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GameDesignerPropertyEntityComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GameDesignerPropertyEntityComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
