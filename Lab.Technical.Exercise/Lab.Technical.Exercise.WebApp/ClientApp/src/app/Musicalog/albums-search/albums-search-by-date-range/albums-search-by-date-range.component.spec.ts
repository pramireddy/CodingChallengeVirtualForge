import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlbumsSearchByDateRangeComponent } from './albums-search-by-date-range.component';

describe('AlbumsSearchByDateRangeComponent', () => {
  let component: AlbumsSearchByDateRangeComponent;
  let fixture: ComponentFixture<AlbumsSearchByDateRangeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlbumsSearchByDateRangeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlbumsSearchByDateRangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
