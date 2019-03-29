import { TestBed } from '@angular/core/testing';

import { SpotfyService } from './spotfy.service';

describe('SpotfyService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SpotfyService = TestBed.get(SpotfyService);
    expect(service).toBeTruthy();
  });
});
