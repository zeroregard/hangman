import { Component, OnInit } from '@angular/core';
import { HangmanAPIService } from 'src/app/services/hangman-api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  constructor(private hangmanAPI: HangmanAPIService, private router: Router) {
    this.hangmanAPI.getGameState();
   }

  ngOnInit() {
    this.hangmanAPI.State.subscribe(state => {
      if (state === undefined) {
        return;
      }
      if (state.status === 'Won') {
        this.router.navigate(['won']);

      } else if (state.status === 'Lost') {
        this.router.navigate(['lost']);
      }
    });
  }

}
