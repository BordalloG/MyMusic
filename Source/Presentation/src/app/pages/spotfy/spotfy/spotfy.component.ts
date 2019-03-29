import { Component, OnInit } from '@angular/core';
import { SpotfyService } from '../spotfy.service';
import { Music } from 'src/app/models/music.model';
import { MusicService } from '../../music/music.service';

@Component({
  selector: 'mm-spotfy',
  templateUrl: './spotfy.component.html',
  styleUrls: ['./spotfy.component.scss']
})
export class SpotfyComponent implements OnInit {

  constructor(private spotfyService: SpotfyService, private musicService: MusicService) { }
  public musics: Music[] = new Array<Music>();

  playlistUrl: string;

  ngOnInit() {
  }

  import() {
    var idPLaylist = this.playlistUrl.split("playlist/")[1];
    this.spotfyService.getTracks(idPLaylist)

      .subscribe(
        res => { this.fillMusic(res); },
        err => { console.log(err); });
  }


  fillMusic(res: any) {
    console.log(res);
    res.items.forEach(element => {
      const durationMusic = new Date(1000*Math.round(element.track.duration_ms / 1000));
      this.musics.push(
        {
          author: element.track.artists[0].name,
          duration: durationMusic.getUTCHours() + ':' + durationMusic.getUTCMinutes() + ':' + durationMusic.getUTCSeconds() ,
          title: element.track.name,
          id: 0
        });
    });
  }

  saveMusic(){
    this.musicService.insertRange(this.musics)
    .subscribe(
      res => { console.log (res); },
      err => { console.log (err); }
    )
  }
}
