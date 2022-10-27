import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MagicBasicsComponent } from './magic-basics.component';

describe('MagicBasicsComponent', () => {
  let component: MagicBasicsComponent;
  let fixture: ComponentFixture<MagicBasicsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MagicBasicsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MagicBasicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
