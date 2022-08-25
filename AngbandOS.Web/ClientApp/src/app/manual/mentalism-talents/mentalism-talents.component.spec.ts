import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentalismTalentsComponent } from './mentalism-talents.component';

describe('MentalismTalentsComponent', () => {
  let component: MentalismTalentsComponent;
  let fixture: ComponentFixture<MentalismTalentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MentalismTalentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MentalismTalentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
