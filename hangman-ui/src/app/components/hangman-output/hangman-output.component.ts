import { Component, OnInit } from '@angular/core';
import { HangmanAPIService } from 'src/app/services/hangman-api.service';

@Component({
  selector: 'app-hangman-output',
  templateUrl: './hangman-output.component.html',
  styleUrls: ['./hangman-output.component.css']
})
export class HangmanOutputComponent implements OnInit {
  private output: string;
  constructor(private hangmanAPI: HangmanAPIService) { }

  ngOnInit() {
    this.hangmanAPI.State.subscribe(state => {
      if (state === undefined) {
        return;
      }
      this.output = state.guessedWord;
    });
  }

}
