import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { MusicService } from '../music.service';
import { Music } from 'src/app/models/music.model';

@Component({
  selector: 'mm-music-detail-dialog',
  templateUrl: './music-detail-dialog.component.html',
  styleUrls: ['./music-detail-dialog.component.scss']
})
export class MusicDetailDialogComponent implements OnInit {

  constructor(private musicService: MusicService,
              public dialogRef: MatDialogRef<MusicDetailDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data:{ id: number }) { }
  music: Music = new Music();
  ngOnInit() {
    this.getMusicData(this.data.id);
  }

 getMusicData(id: number) {
  this.musicService.getMusicById(id)
  .subscribe(
    res => {this.music = res; },
    err => {console.log(err); }
    );
 }

 close(): void {
  this.dialogRef.close();
 }
}
