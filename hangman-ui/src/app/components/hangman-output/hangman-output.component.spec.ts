import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HangmanOutputComponent } from './hangman-output.component';

describe('HangmanOutputComponent', () => {
  let component: HangmanOutputComponent;
  let fixture: ComponentFixture<HangmanOutputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HangmanOutputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HangmanOutputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
