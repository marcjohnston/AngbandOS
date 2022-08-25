import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MysticComponent } from './mystic.component';

describe('MysticComponent', () => {
  let component: MysticComponent;
  let fixture: ComponentFixture<MysticComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MysticComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MysticComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
