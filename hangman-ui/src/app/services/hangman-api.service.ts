import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment'
import { GameState } from '../models/gameState';
import { Observable, Subject, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HangmanAPIService {

  constructor(private http: HttpClient) { }
  public State = new BehaviorSubject<GameState>(undefined);
  private gameController = '/game';
  private highscoreController = '/highscore';
  private gameIdKey = 'game_id';

  async startGame() {
    const result = await this
                          .http
                          .post(environment.hangman_api_endpoint + this.gameController, '')
                          .toPromise();
    const gameState = result as GameState;
    localStorage.setItem(this.gameIdKey, gameState.id);
    this.State.next(gameState);
  }

  async getHighscore() {
    const id = localStorage.getItem(this.gameIdKey);
    const result = await this
                          .http
                          .get(environment.hangman_api_endpoint + `${this.highscoreController}/${id}`)
                          .toPromise();
    return result as number;
  }

  async guessLetter(letter: string) {
    const id = localStorage.getItem(this.gameIdKey);
    const result = await this
                          .http
                          .post(environment.hangman_api_endpoint + `${this.gameController}/${id}?letter=${letter}`, '')
                          .toPromise();
    this.State.next(result as GameState);
  }

  async getGameState() {
    const id = localStorage.getItem(this.gameIdKey);
    const result = await this
                          .http
                          .get(environment.hangman_api_endpoint + `${this.gameController}/${id}`)
                          .toPromise();
    this.State.next(result as GameState);
    return this.State;
  }

}
