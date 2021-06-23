import { Component, OnInit } from '@angular/core';
import { IAlbum } from 'src/app/core/models/album';

@Component({
  selector: 'app-albums-search',
  templateUrl: './albums-search.component.html',
  styleUrls: ['./albums-search.component.css']
})
export class AlbumsSearchComponent implements OnInit {
  
  searchString: string = '';
  searchByAlbumIdResult: IAlbum;
  constructor() { }

  ngOnInit(): void {
  }

  onSeachByAlbumId(value: IAlbum): void {
    this.searchByAlbumIdResult = value;
    this.searchString = '';
  }
  onSeachByCreationDateRange(value: string): void {
    this.searchByAlbumIdResult = undefined;
    this.searchString = value;
  }

}
