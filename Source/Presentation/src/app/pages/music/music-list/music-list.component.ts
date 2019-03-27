import { Component, OnInit } from '@angular/core';

import { MusicService } from '../music.service';
import { Music } from 'src/app/models/music.model';
import { MatTableDataSource, MatFormFieldControl } from '@angular/material';


@Component({
  selector: 'mm-music-list',
  templateUrl: './music-list.component.html',
  styleUrls: ['./music-list.component.scss']
})
export class MusicListComponent implements OnInit {

  constructor(private musicService: MusicService) { }

  displayedColumns: string[] = ['Author', 'Title', 'Duration'];
  dataSource = new MatTableDataSource();
  filterText = '';
  sortOrder = '';
  ngOnInit() {
    this.getAllMusics(this.sortOrder,this.filterText);
  }

  getAllMusics(sortOrder: string, text: string){
    this.musicService.getAllMatchs(sortOrder, text)
    .subscribe(
      res => {
        this.dataSource = new MatTableDataSource(res);
        console.log(res);
      },
      err => {
        console.log('Falhou!! ', err);
      }
    );
  }

  applyTextFilter() {
    this.getAllMusics(this.sortOrder, this.filterText);
  }

  applySortOrderFilter(sortOrder: string) {
    this.sortOrder = sortOrder;
    this.getAllMusics(this.sortOrder, this.filterText);
  }
}
