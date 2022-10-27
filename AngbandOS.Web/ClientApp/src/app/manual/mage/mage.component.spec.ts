import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MageComponent } from './mage.component';

describe('MageComponent', () => {
  let component: MageComponent;
  let fixture: ComponentFixture<MageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
