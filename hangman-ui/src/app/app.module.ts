import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

import { HangmanInputComponent } from './components/hangman-input/hangman-input.component';
import { HangmanOutputComponent } from './components/hangman-output/hangman-output.component';
import { KeyboardButtonComponent } from './components/keyboard-button/keyboard-button.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { GameComponent } from './components/game/game.component';
import { GuessesComponent } from './components/guesses/guesses.component';
import { WonComponent } from './components/won/won.component';
import { LostComponent } from './components/lost/lost.component';
import { ReplayComponent } from './components/replay/replay.component';

@NgModule({
  declarations: [
    AppComponent,
    HangmanInputComponent,
    HangmanOutputComponent,
    KeyboardButtonComponent,
    WelcomeComponent,
    GameComponent,
    GuessesComponent,
    WonComponent,
    LostComponent,
    ReplayComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
