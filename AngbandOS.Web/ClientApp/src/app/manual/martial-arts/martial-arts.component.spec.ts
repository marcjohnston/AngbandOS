import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MartialArtsComponent } from './martial-arts.component';

describe('MartialArtsComponent', () => {
  let component: MartialArtsComponent;
  let fixture: ComponentFixture<MartialArtsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MartialArtsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MartialArtsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
