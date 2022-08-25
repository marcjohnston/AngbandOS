import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WarriorComponent } from './warrior.component';

describe('WarriorComponent', () => {
  let component: WarriorComponent;
  let fixture: ComponentFixture<WarriorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WarriorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WarriorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
