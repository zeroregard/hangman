import { TestBed } from '@angular/core/testing';

import { HangmanAPIService } from './hangman-api.service';

describe('HangmanAPIService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HangmanAPIService = TestBed.get(HangmanAPIService);
    expect(service).toBeTruthy();
  });
});
