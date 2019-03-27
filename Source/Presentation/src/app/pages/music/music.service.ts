import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from './../../../environments/environment';
import { Observable } from 'rxjs';
import { Music } from 'src/app/models/music.model';
@Injectable({
  providedIn: 'root'
})
export class MusicService {

   uri = environment.baseUri + 'Music';

  constructor(private http: HttpClient) { }

  public getAllMatchs(sortOrderRequest: string, textRequest: string): Observable<Music[]> {
    return this.http.post<Music[]>(this.uri + '/GetAll', { sortOrder: sortOrderRequest, text: textRequest });
  }
}
