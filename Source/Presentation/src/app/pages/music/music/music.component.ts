import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MusicService } from '../music.service';
import { Music } from 'src/app/models/music.model';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'mm-music',
  templateUrl: './music.component.html',
  styleUrls: ['./music.component.scss']
})
export class MusicComponent implements OnInit {

  listMusicSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  constructor() { }

  ngOnInit() {
  }

  musicListUpdate( updated: boolean) {
    this.listMusicSubject.next(updated);
  }
}
