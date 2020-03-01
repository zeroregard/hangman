import { Component, OnInit } from '@angular/core';
import { HangmanAPIService } from 'src/app/services/hangman-api.service';

@Component({
  selector: 'app-guesses',
  templateUrl: './guesses.component.html',
  styleUrls: ['./guesses.component.css']
})
export class GuessesComponent implements OnInit {
  private guesses: string;
  constructor(private hangmanAPI: HangmanAPIService) { }

  ngOnInit() {
    this.hangmanAPI.State.subscribe(state => {
      if (state === undefined) {
        return;
      }
      this.guesses = state.guessesLeft.toString();
    });
  }

}
