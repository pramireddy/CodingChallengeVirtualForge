import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CoreModule } from './core/core.module';
import { MaterialModule } from './material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AlbumDetailsComponent } from './Musicalog/album-details/album-details.component';
import { AlbumCreateComponent } from './Musicalog/album-create/album-create.component';
import { AlbumUpdateComponent } from './Musicalog/album-update/album-update.component';
import { AlbumsSearchComponent } from './Musicalog/albums-search/albums-search.component';
import { AlbumsSearchByAlbumidComponent } from './Musicalog/albums-search/albums-search-by-albumid/albums-search-by-albumid.component';
import { AlbumsSearchByDateRangeComponent } from './Musicalog/albums-search/albums-search-by-date-range/albums-search-by-date-range.component';
import { AlbumSummaryComponent } from './Musicalog/albums-search/album-summary/album-summary.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AlbumDetailsComponent,
    AlbumCreateComponent,
    AlbumUpdateComponent,
    AlbumsSearchComponent,
    AlbumsSearchByAlbumidComponent,
    AlbumsSearchByDateRangeComponent,
    AlbumSummaryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'search-albums', component: AlbumsSearchComponent },
      { path: 'update', component: AlbumUpdateComponent },
      { path: 'create', component: AlbumCreateComponent },
      { path: 'albums', component: AlbumDetailsComponent },
    ]),
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
