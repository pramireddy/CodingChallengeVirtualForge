import { Injectable } from '@angular/core';
import { LoggerService } from './logger.service';
import { AppService } from './app.service';
import { Observable } from 'rxjs';
import { IAlbum, IAlbumFormOptionsData, ICreateAlbumRequest } from '../models/album';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  constructor(private logger: LoggerService, private apiService: AppService) { }

  fetchAlbums(): Observable<IAlbum[]> {
    let renVal: Observable<IAlbum[]>;
    this.logger.trace(`Albums service:fetchAlbums`)
    renVal = this.apiService.get('api/albums');
    this.logger.trace(`Albums service:fetchAlbums`)
    return renVal;
  }

  fetchAlbumFormOptionsData(): Observable<IAlbumFormOptionsData> {
    let renVal: Observable<IAlbumFormOptionsData>;
    this.logger.trace(`Albums service:fetchAlbumFormOptionsData`)
    renVal = this.apiService.get('api/albums/GetAlbumFormOptionsData');
    this.logger.trace(`Albums service:fetchAlbumFormOptionsData`)
    return renVal;
  }

  fetchAlbumById(albumId:number): Observable<IAlbum> {
    let renVal: Observable<IAlbum>;
    this.logger.trace(`Albums service:fetchAlbumById:${albumId}`)
    renVal = this.apiService.get(`api/albums/${albumId}`);
    this.logger.trace(`Albums service:fetchAlbumById:${albumId}`)
    return renVal;
  }

  creatNewAlbum(createAlbumRequest: ICreateAlbumRequest): Observable<any> {
    let renVal: Observable<any>;
    this.logger.trace(`--> Creating new album(${createAlbumRequest.albumName})`);
    renVal = this.apiService.post('/api/albums', createAlbumRequest);
    this.logger.trace(`--> New Album created(${createAlbumRequest.albumName})`);
    return renVal;
  }
}
