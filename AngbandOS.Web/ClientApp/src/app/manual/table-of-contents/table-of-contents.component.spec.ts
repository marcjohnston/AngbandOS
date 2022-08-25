import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableOfContentsComponent } from './table-of-contents.component';

describe('TableOfContentsComponent', () => {
  let component: TableOfContentsComponent;
  let fixture: ComponentFixture<TableOfContentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableOfContentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableOfContentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
