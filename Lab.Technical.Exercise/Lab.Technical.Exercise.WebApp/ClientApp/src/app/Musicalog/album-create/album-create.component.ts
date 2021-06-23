import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Location } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';

import { MatDialog } from '@angular/material/dialog';

import { SuccessDialogComponent } from '../../core/dialogs/success-dialog/success-dialog.component'
import { ErrorDialogComponent } from '../../core/dialogs/error-dialog/error-dialog.component'
import { AlbumService, LoggerService, ScenariosService } from '../../core/services';
import { IAlbum, IAlbumFormOptionsData, ICreateAlbumRequest } from '../../core/models/Album';

@Component({
  selector: 'app-album-create',
  templateUrl: './album-create.component.html',
  styleUrls: ['./album-create.component.css']
})
export class AlbumCreateComponent implements OnInit {

  public ownerForm: FormGroup = new FormGroup({});
  private dialogConfig;
  selectedCar: string;
  selectedValue: string;
  formOptionsData: IAlbumFormOptionsData;
  types = [
    { id: 111, name: 'CD' },
    { id: 222, name: 'Vinyl' }
  ];

  constructor(private location: Location, private fb: FormBuilder, private dialog: MatDialog, private albumService: AlbumService, private logger: LoggerService) { }

  ngOnInit(): void {
    this.ownerForm = this.fb.group({
      albumName: ['', [Validators.required]],
      artistId: ['', [Validators.required]],
      labelId: ['', [Validators.required]],
      albumType: ['', [Validators.required]],
      stock: ['', [Validators.required]],
    });

    this.dialogConfig = {
      height: '200px',
      width: '400px',
      disableClose: true,
      data: {}
    }

    this.fetchAlbumFormOptionsData()
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.ownerForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.location.back();
  }
  public createOwner = (ownerFormValue: ICreateAlbumRequest) => {
    if (this.ownerForm.valid) {

      this.creatNewAlbum(ownerFormValue);
      console.log(ownerFormValue);

    }
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

  private creatNewAlbum(request: ICreateAlbumRequest) {
    this.albumService.creatNewAlbum(request)
      .subscribe(
        {
          next: (result: any) => {

            console.log(result);
            let dialogRef = this.dialog.open(SuccessDialogComponent, this.dialogConfig);

            dialogRef.afterClosed()
              .subscribe(result => {
                this.location.back();
              });

          },
          error: (error: any) => {
            // this.logger.error("Failed to Fetch Scenarios" + error);
            console.log(error);

          },
          complete: () => {
            // this.logger.trace("Fetch Scenarios succcess");
          }
        }
      );
  }

}
