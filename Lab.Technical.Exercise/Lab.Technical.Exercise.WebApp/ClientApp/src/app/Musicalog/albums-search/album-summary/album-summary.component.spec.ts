import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlbumSummaryComponent } from './album-summary.component';

describe('AlbumSummaryComponent', () => {
  let component: AlbumSummaryComponent;
  let fixture: ComponentFixture<AlbumSummaryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlbumSummaryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlbumSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
