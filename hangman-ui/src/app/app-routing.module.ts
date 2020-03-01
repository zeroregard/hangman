import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GameComponent } from './components/game/game.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { WonComponent } from './components/won/won.component';
import { LostComponent } from './components/lost/lost.component';


const routes: Routes = [
  { path: '', component: WelcomeComponent},
  { path: 'game', component: GameComponent },
  { path: 'won', component: WonComponent},
  { path: 'lost', component: LostComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
