import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaladinComponent } from './paladin.component';

describe('PaladinComponent', () => {
  let component: PaladinComponent;
  let fixture: ComponentFixture<PaladinComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaladinComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaladinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
