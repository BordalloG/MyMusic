import { Component, OnInit, Inject } from '@angular/core';
import { MusicService } from '../music.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Music } from 'src/app/models/music.model';

@Component({
  selector: 'mm-music-edit-dialog',
  templateUrl: './music-edit-dialog.component.html',
  styleUrls: ['./music-edit-dialog.component.scss']
})
export class MusicEditDialogComponent implements OnInit {

  constructor(private musicService: MusicService,
              public dialogRef: MatDialogRef<MusicEditDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: { id: number }) { }

    music: Music = new Music();
  ngOnInit() {
    this.getMusicData(this.data.id);
  }

  getMusicData(id: number) {
    this.musicService.getMusicById(id)
    .subscribe(
      res => {
        this.music = res;
       },
      err => {console.log(err); }
      );
   }

   updateMusic(){
    const musicRequest = this.music;
    musicRequest.duration =
    this.music.duration.substring(0, 2) + ':' + this.music.duration.substring(2, 4) + ':' + this.music.duration.substring(4, 6) ;
    this.musicService.updateMusicBy(this.data.id, musicRequest)
    .subscribe(
      res => {console.log(res); this.dialogRef.close(); },
      err => {console.log(err); }
    );
   }
   close(): void {
    this.dialogRef.close();
   }
}
