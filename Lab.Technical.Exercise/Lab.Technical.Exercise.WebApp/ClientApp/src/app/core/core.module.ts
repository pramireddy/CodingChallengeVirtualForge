import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppService, LoggerService, ScenariosService } from './services';
import { AlbumService } from './services/album.service';
import { ErrorDialogComponent } from './dialogs/error-dialog/error-dialog.component';
import { SuccessDialogComponent } from './dialogs/success-dialog/success-dialog.component';


@NgModule({
  declarations: [ErrorDialogComponent, SuccessDialogComponent],
  imports: [
    CommonModule
  ],
  providers: [
    AppService,
    LoggerService,
    ScenariosService,
    AlbumService
  ],
  exports: []
})
export class CoreModule { }
