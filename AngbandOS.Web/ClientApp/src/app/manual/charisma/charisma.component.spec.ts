import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharismaComponent } from './charisma.component';

describe('CharismaComponent', () => {
  let component: CharismaComponent;
  let fixture: ComponentFixture<CharismaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CharismaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CharismaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
