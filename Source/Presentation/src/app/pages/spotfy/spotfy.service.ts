import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpotfyService {

  uriStart = 'https://api.spotify.com/v1/playlists/';
  uriEnd = '/tracks?market=BR&fields=items(track(name%2Cduration_ms%2Cartists))&limit=10&offset=0';
  constructor(private http: HttpClient) { }

  getTracks(idPLaylist: string): Observable<string> {
    return this.http.post<string>('https://localhost:44320/api/Music/GetTracksFromSpotify', {Data: (this.uriStart + idPLaylist + this.uriEnd)});
  }
}
