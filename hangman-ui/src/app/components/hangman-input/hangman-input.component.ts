import { Component, OnInit } from '@angular/core';
import { HangmanAPIService } from '../../services/hangman-api.service';
import { KeyboardButtonComponent } from '../keyboard-button/keyboard-button.component';

@Component({
  selector: 'app-hangman-input',
  templateUrl: './hangman-input.component.html',
  styleUrls: ['./hangman-input.component.css']
})
export class HangmanInputComponent implements OnInit {

  constructor() { }
  FirstRow: string[] = ['1', '2', '3', '4', '5', '6', '7', '8', '0'];
  SecondRow: string[] = ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'];
  ThirdRow: string[] = ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'];
  FourthRow: string[] = ['z', 'x', 'c', 'v', 'b', 'n', 'm'];

  ngOnInit() {
  }

}
