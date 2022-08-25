import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DexterityComponent } from './dexterity.component';

describe('DexterityComponent', () => {
  let component: DexterityComponent;
  let fixture: ComponentFixture<DexterityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DexterityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DexterityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
