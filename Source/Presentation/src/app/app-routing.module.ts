import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home/home.component';
import { MusicComponent } from './pages/music/music/music.component';
import { SpotfyComponent } from './pages/spotfy/spotfy/spotfy.component';

const routes: Routes = [
  {path: '', redirectTo: 'Home', pathMatch: 'full'},
  { path: 'Home', component: HomeComponent },
  { path: 'Music', component: MusicComponent },
  { path: 'ImportFromSpotify', component: SpotfyComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
