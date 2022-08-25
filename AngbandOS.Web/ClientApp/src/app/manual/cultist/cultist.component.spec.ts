import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CultistComponent } from './cultist.component';

describe('CultistComponent', () => {
  let component: CultistComponent;
  let fixture: ComponentFixture<CultistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CultistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CultistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
