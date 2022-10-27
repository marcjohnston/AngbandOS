import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonkComponent } from './monk.component';

describe('MonkComponent', () => {
  let component: MonkComponent;
  let fixture: ComponentFixture<MonkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MonkComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MonkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
