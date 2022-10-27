import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WarriorMageComponent } from './warrior-mage.component';

describe('WarriorMageComponent', () => {
  let component: WarriorMageComponent;
  let fixture: ComponentFixture<WarriorMageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WarriorMageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WarriorMageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
