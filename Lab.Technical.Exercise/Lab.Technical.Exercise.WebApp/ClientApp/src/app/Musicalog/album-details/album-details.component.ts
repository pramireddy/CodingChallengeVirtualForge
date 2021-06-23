import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { AlbumService, LoggerService } from '../../core/services';
import { AlbumType, IAlbum } from '../../core/models/album';

@Component({
  selector: 'app-album-details',
  templateUrl: './album-details.component.html',
  styleUrls: ['./album-details.component.css']
})
export class AlbumDetailsComponent implements OnInit {

  displayedColumns: string[] = ['name', 'artist','type', 'stock', 'update', 'delete'];
  dataSource: IAlbum[] = [];
  filteredDataSource = new MatTableDataSource<IAlbum>();
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  filter: string = '';

  constructor(private albumService: AlbumService, private logger: LoggerService) {
  }

  ngOnInit(): void {
    this.fectechAlbums();
  }

  // private fectechAlbums() {
  //   this.dataSource = this.getAlbums();
  //   this.filteredDataSource.data = this.dataSource;
  //   this.filteredDataSource = new MatTableDataSource(this.dataSource);
  //   this.filteredDataSource.paginator = this.paginator;
  //   this.filteredDataSource.sort = this.sort;
  // }

  private fectechAlbums() {
    this.albumService.fetchAlbums()
      .subscribe(
        {
          next: (result: IAlbum[]) => {
            this.dataSource = result;
            this.filteredDataSource.data = this.dataSource;
            this.filteredDataSource = new MatTableDataSource(this.dataSource);
            this.filteredDataSource.paginator = this.paginator;
            this.filteredDataSource.sort = this.sort;
          },
          error: (error: any) => {
            this.logger.error("Failed to Fetch Scenarios" + error);
          },
          complete: () => {
            this.logger.trace("Fetch Scenarios succcess");
          }
        }
      );
  }

  ngAfterViewInit(): void {
    this.filteredDataSource.paginator = this.paginator;
    this.filteredDataSource.sort = this.sort;
    this.filteredDataSource.sortingDataAccessor = (item, property) => {
      switch (property) {
         case 'artist': return  item.artist.name;
         case 'stock': return   item.stock.quantity;
         default: return item[property];
      }
    }
    
  }

  applyFilter() {
    if (!this.dataSource)
      return;
    let lowerFilter = this.filter.toLowerCase();
    this.filteredDataSource.data = this.dataSource.filter(x =>
      this.filter === '' ||
      (x.name.toLowerCase().includes(lowerFilter) ||
        x.artist.name.toLowerCase().includes(lowerFilter) ||
        x.type.toString().toLowerCase().includes(lowerFilter) ||
        x.stock.quantity.toString().toLowerCase().includes(lowerFilter))
    );
  }

  public redirectToUpdate = (id: number) => {
    console.log(id)
  }
  public redirectToDelete = (id: number) => {
    console.log(id)
  }

  clearFilter() {
    this.filter = '';
    this.applyFilter();
  }

  getAlubumType(type: number) {
    return AlbumType.get(type);
  };

}
