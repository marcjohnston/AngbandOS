import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChannelerComponent } from './channeler.component';

describe('ChannelerComponent', () => {
  let component: ChannelerComponent;
  let fixture: ComponentFixture<ChannelerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChannelerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChannelerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
