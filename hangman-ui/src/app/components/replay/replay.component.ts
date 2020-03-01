import { Component, OnInit, Input } from '@angular/core';
import { HangmanAPIService } from 'src/app/services/hangman-api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-replay',
  templateUrl: './replay.component.html',
  styleUrls: ['./replay.component.css']
})
export class ReplayComponent implements OnInit {

  @Input() Label: string;
  constructor(private hangmanAPI: HangmanAPIService, private router: Router) { }

  ngOnInit() {
  }

  async replay() {
    await this.hangmanAPI.startGame();
    this.router.navigate(['/game']);
  }

}
