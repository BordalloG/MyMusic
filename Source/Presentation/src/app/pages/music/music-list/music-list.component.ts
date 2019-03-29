import { Component, OnInit, Input } from '@angular/core';

import { MusicService } from '../music.service';
import { Music } from 'src/app/models/music.model';
import { MatTableDataSource, MatFormFieldControl, MatDialog } from '@angular/material';
import { MusicDetailDialogComponent } from '../music-detail-dialog/music-detail-dialog.component';
import { MusicEditDialogComponent } from '../music-edit-dialog/music-edit-dialog.component';


@Component({
  selector: 'mm-music-list',
  templateUrl: './music-list.component.html',
  styleUrls: ['./music-list.component.scss']
})
export class MusicListComponent implements OnInit {

  @Input() listMusic;
  constructor(private musicService: MusicService, public dialog: MatDialog) { }

  displayedColumns: string[] = ['Author', 'Title', 'Duration', 'Actions'];
  dataSource = new MatTableDataSource();
  filterText = '';
  sortOrder = '';

  ngOnInit() {
    this.getAllMusics(this.sortOrder, this.filterText);
    this.listMusic
      .asObservable()
      .subscribe((x: boolean) => {
        if (x) {
          this.getAllMusics(this.sortOrder, this.filterText);
        }
        return;
      });
  }

  getAllMusics(sortOrder: string, text: string) {
    console.log('sort order: ', sortOrder);
    this.musicService.getAllMusics(sortOrder, text)
      .subscribe(
        res => {
          this.dataSource = new MatTableDataSource(res);
        },
        err => {
          if (err.status === 404) {
            this.dataSource = new MatTableDataSource();
          }
          console.log(err);
        }
      );
  }
  editMusic(idMusic: number) {
    const dialogRef = this.dialog.open(MusicEditDialogComponent,
      {
        data: {
          id: idMusic
        }
      });

    dialogRef.afterClosed().subscribe(result => {
      console.log("fechei edição");
      this.getAllMusics(this.sortOrder, this.filterText);
    });
  }
  deleteMusic(idMusic: number) {
    this.musicService.removeMusic(idMusic)
      .subscribe(
        res => {
          this.getAllMusics(this.sortOrder, this.filterText);
        },
        err => { console.log(err); }
      );
  }

  showDetails(idMusic: number) {
    const dialogRef = this.dialog.open(MusicDetailDialogComponent,
      {
        data: {
          id: idMusic
        }
      });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  applyTextFilter() {
    this.getAllMusics(this.sortOrder, this.filterText);
  }

  applySortOrderFilter(sortOrder: string) {
    sortOrder = sortOrder === this.sortOrder ? ' ' : sortOrder;
    this.sortOrder = sortOrder;
    this.getAllMusics(this.sortOrder, this.filterText);
  }
}
