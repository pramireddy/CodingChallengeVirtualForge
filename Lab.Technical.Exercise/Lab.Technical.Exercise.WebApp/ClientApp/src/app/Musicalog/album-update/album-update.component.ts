import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Location } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';

import { MatDialog } from '@angular/material/dialog';
import { AlbumService, LoggerService, ScenariosService } from '../../core/services';
import { IAlbum,IAlbumFormOptionsData,ICreateAlbumRequest } from '../../core/models/Album';

@Component({
  selector: 'app-album-update',
  templateUrl: './album-update.component.html',
  styleUrls: ['./album-update.component.css']
})
export class AlbumUpdateComponent implements OnInit {
  // TO DO : Update form name
  public ownerForm: FormGroup = new FormGroup({});
  private dialogConfig;
  selectedCar: string;
  selectedValue: string;
  formOptionsData : IAlbumFormOptionsData;
  types = [
    { id: 111, name: 'CD' },
    { id: 222, name: 'Vinyl' }
  ];

  constructor(private location: Location, private fb: FormBuilder, private dialog: MatDialog,private albumService: AlbumService,private logger: LoggerService) { }

  ngOnInit(): void {
    this.ownerForm = this.fb.group({
      albumName: ['', [Validators.required]],
      artistId: ['', [Validators.required]],
      labelId: ['', [Validators.required]],
      albumType: ['', [Validators.required]],
      stock: ['', [Validators.required]],
    });

    this.setupDialog();

    this. fetchAlbumFormOptionsData()
    this.setFormCurrentValues();
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.ownerForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.location.back();
  }
  public createOwner = (ownerFormValue) => {
    if (this.ownerForm.valid) {
      console.log(ownerFormValue);
    }
  }

  private setupDialog() {
    this.dialogConfig = {
      height: '200px',
      width: '400px',
      disableClose: true,
      data: {}
    };
  }

  setFormCurrentValues() {
    this.ownerForm.setValue({
      albumName: 'test',
      artistId: 111,
      albumType: this.types[0].id,
      labelId: 222,
      stock: 111
    })
  }

  private fetchAlbumFormOptionsData() {
    this.albumService.fetchAlbumFormOptionsData()
      .subscribe(
        {
          next: (result: IAlbumFormOptionsData) => {
            this.formOptionsData = result;
          },
          error: (error: any) => {
            this.logger.error("Failed to Fetch Form Options Data" + error);
          },
          complete: () => {
            this.logger.trace("Fetch Form Options Data succcess");
          }
        }
      );
  }

}
