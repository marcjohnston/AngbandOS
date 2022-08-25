import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WisdomComponent } from './wisdom.component';

describe('WisdomComponent', () => {
  let component: WisdomComponent;
  let fixture: ComponentFixture<WisdomComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WisdomComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WisdomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
