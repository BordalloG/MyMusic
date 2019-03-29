import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {MatButtonModule} from '@angular/material/button';
import {MatBottomSheetModule} from '@angular/material/bottom-sheet';
import {MatMenuModule} from '@angular/material/menu';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { MatTableModule, MatSortModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import {MatDialogModule} from '@angular/material/dialog';
import {MatDividerModule} from '@angular/material/divider';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import {MatExpansionModule} from '@angular/material/expansion';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MusicComponent } from './pages/music/music/music.component';
import { MusicRegisterComponent } from './pages/music/music-register/music-register.component';
import { MusicListComponent } from './pages/music/music-list/music-list.component';
import { HomeComponent } from './pages/home/home/home.component';
import { MusicDetailDialogComponent } from './pages/music/music-detail-dialog/music-detail-dialog.component';
import { SidenavComponent } from './layout/sidenav/sidenav.component';
import {NgxMaskModule} from 'ngx-mask';
import { MusicEditDialogComponent } from './pages/music/music-edit-dialog/music-edit-dialog.component';
import { SpotfyComponent } from './pages/spotfy/spotfy/spotfy.component';

@NgModule({
  declarations: [
    AppComponent,
    MusicComponent,
    MusicRegisterComponent,
    MusicListComponent,
    HomeComponent,
    MusicDetailDialogComponent,
    SidenavComponent,
    MusicEditDialogComponent,
    SpotfyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    HttpClientModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatBottomSheetModule,
    MatMenuModule,
    MatSnackBarModule,
    MatDialogModule,
    MatDividerModule,
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    NgxMaskModule.forRoot(),
    MatCardModule,
    MatExpansionModule
  ],
  entryComponents: [
    MusicDetailDialogComponent,
    MusicEditDialogComponent
  ],
  providers: [
    HttpClientModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
