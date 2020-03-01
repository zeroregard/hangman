import { Component, OnInit } from '@angular/core';
import { HangmanAPIService } from 'src/app/services/hangman-api.service';

@Component({
  selector: 'app-won',
  templateUrl: './won.component.html',
  styleUrls: ['./won.component.css']
})
export class WonComponent implements OnInit {
  private highscore: number;
  private word: string;
  constructor(private hangmanAPI: HangmanAPIService) { }

  async ngOnInit() {
    const state = this.hangmanAPI.State.value;
    this.word = state.guessedWord;
    this.highscore = await this.hangmanAPI.getHighscore();
  }

}
