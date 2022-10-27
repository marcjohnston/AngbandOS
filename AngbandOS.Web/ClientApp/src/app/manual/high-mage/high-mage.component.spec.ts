import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HighMageComponent } from './high-mage.component';

describe('HighMageComponent', () => {
  let component: HighMageComponent;
  let fixture: ComponentFixture<HighMageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HighMageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HighMageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
