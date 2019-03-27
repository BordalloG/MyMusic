import { Component, OnInit } from '@angular/core';
import { MusicService } from '../music.service';
import { Music } from 'src/app/models/music.model';

@Component({
  selector: 'mm-music',
  templateUrl: './music.component.html',
  styleUrls: ['./music.component.scss']
})
export class MusicComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
