import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Music } from 'src/app/models/music.model';
import { MusicService } from '../music.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'mm-music-register',
  templateUrl: './music-register.component.html',
  styleUrls: ['./music-register.component.scss']
})
export class MusicRegisterComponent implements OnInit {

  @Output() musicAdded: EventEmitter<boolean> =  new EventEmitter(false);

  constructor(private musicService: MusicService, private snackBar: MatSnackBar) {
    this.music = {id: 0, author: '', title: '' , duration: '000000' };
   }


   music: Music;

   ngOnInit() {
  }

  saveMusic() {
    const musicRequest = this.music;
    musicRequest.duration =
    this.music.duration.substring(0, 2) + ':' + this.music.duration.substring(2, 4) + ':' + this.music.duration.substring(4, 6) ;

    this.musicService.insertMusic(musicRequest)
    .subscribe(
      res => {
        this.snackBar.open( 'A música ' + this.music.title + ' foi inserida com sucesso.', 'Fechar', {
          duration: 3000
        });
        this.music = new Music();
        this.musicAdded.emit(true);
      },
      err => { console.log(err); }
    );
  }
}
