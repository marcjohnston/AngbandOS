import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DruidComponent } from './druid.component';

describe('DruidComponent', () => {
  let component: DruidComponent;
  let fixture: ComponentFixture<DruidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DruidComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DruidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
