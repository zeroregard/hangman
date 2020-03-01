import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HangmanInputComponent } from './hangman-input.component';

describe('HangmanInputComponent', () => {
  let component: HangmanInputComponent;
  let fixture: ComponentFixture<HangmanInputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HangmanInputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HangmanInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
