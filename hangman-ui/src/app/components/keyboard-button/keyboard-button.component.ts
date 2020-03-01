import { Component, OnInit, Input } from '@angular/core';
import { HangmanAPIService } from 'src/app/services/hangman-api.service';
import { GameState } from 'src/app/models/gameState';
import { HostListener } from '@angular/core';

@Component({
  selector: 'app-keyboard-button',
  templateUrl: './keyboard-button.component.html',
  styleUrls: ['./keyboard-button.component.css']
})
export class KeyboardButtonComponent implements OnInit {
  @Input() Letter: string;
  private isDisabled = false;
  constructor(private hangmanAPI: HangmanAPIService) { }

  // this.Letter was undefined within this scope for some reason, so passing it as a parameter instead
  onStateUpdated(state: GameState, letter: string) {
    if (state === undefined) {
      return;
    }
    if (state.guessedLetters.includes(letter)) {
      this.isDisabled = true;
    }
  }

  @HostListener('document:keypress', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) { 
    if (event.key === this.Letter && !this.isDisabled) {
      this.guess();
    }
  }

  ngOnInit() {
    this.hangmanAPI.State.subscribe(state => {
      this.onStateUpdated(state, this.Letter);
    });
  }

  guess() {
    this.hangmanAPI.guessLetter(this.Letter);
  }

}
