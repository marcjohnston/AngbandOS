import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PriestComponent } from './priest.component';

describe('PriestComponent', () => {
  let component: PriestComponent;
  let fixture: ComponentFixture<PriestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PriestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PriestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
