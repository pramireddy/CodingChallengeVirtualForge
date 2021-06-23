import { Component, Input, OnInit } from '@angular/core';
import { IAlbum } from 'src/app/core/models/album';

@Component({
  selector: 'app-album-summary',
  templateUrl: './album-summary.component.html',
  styleUrls: ['./album-summary.component.css']
})
export class AlbumSummaryComponent implements OnInit {
  @Input() album: IAlbum;
  displayedColumns: string[] = ['key', 'value'];
  dataSource: IAlbum;
  hideHeader: boolean = true;

  constructor() { }

  ngOnInit(): void {
    this.dataSource = this.album
  }
  public orderByKey(a) {
    return a.key;
  }

}
