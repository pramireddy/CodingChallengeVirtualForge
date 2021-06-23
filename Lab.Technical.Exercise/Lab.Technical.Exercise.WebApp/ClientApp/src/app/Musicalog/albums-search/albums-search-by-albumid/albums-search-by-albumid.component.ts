import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { AlbumService, LoggerService, ScenariosService } from '../../../core/services'

import { IAlbum } from 'src/app/core/models/album';

@Component({
  selector: 'app-albums-search-by-albumid',
  templateUrl: './albums-search-by-albumid.component.html',
  styleUrls: ['./albums-search-by-albumid.component.css']
})
export class AlbumsSearchByAlbumidComponent implements OnInit {
  @Output() notify = new EventEmitter<IAlbum>();
  searchForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private albumService: AlbumService, private logger: LoggerService) { }

  ngOnInit(): void {
    this.searchForm = this.formBuilder.group({
      fileName: new FormControl('', Validators.required),
    });
  }

  search(formValues: { fileName: any; }) {
    let userId = formValues.fileName;
    this.fectechAlbumssByUserId(userId)
  }

  private fectechAlbumssByUserId(albumId: number) {
    this.albumService.fetchAlbumById(albumId)
      .subscribe(
        {
          next: (result: IAlbum) => {
            this.notify.emit(result);
          },
          error: (error: any) => {
            this.logger.error("Failed to Fetch Albums" + error);
          },
          complete: () => {
            this.logger.trace("Fetch Albums succcess");
          }
        }
      );
  }
}
