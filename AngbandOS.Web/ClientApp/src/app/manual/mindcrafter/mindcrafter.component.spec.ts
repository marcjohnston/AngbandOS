import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MindcrafterComponent } from './mindcrafter.component';

describe('MindcrafterComponent', () => {
  let component: MindcrafterComponent;
  let fixture: ComponentFixture<MindcrafterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MindcrafterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MindcrafterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
