import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignerPropertyCollectionComponent } from './game-designer-property-collection.component';

describe('GameDesignerPropertyCollectionComponent', () => {
  let component: GameDesignerPropertyCollectionComponent;
  let fixture: ComponentFixture<GameDesignerPropertyCollectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GameDesignerPropertyCollectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GameDesignerPropertyCollectionComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
