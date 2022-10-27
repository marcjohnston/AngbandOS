import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RogueComponent } from './rogue.component';

describe('RogueComponent', () => {
  let component: RogueComponent;
  let fixture: ComponentFixture<RogueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RogueComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RogueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
