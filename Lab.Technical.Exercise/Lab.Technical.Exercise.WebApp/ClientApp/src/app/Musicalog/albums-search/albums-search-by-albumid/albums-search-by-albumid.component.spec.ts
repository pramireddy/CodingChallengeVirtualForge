import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlbumsSearchByAlbumidComponent } from './albums-search-by-albumid.component';

describe('AlbumsSearchByAlbumidComponent', () => {
  let component: AlbumsSearchByAlbumidComponent;
  let fixture: ComponentFixture<AlbumsSearchByAlbumidComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlbumsSearchByAlbumidComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlbumsSearchByAlbumidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
