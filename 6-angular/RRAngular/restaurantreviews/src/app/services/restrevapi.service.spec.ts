import { TestBed } from '@angular/core/testing';

import { RestrevapiService } from './restrevapi.service';

describe('RestrevapiService', () => {
  let service: RestrevapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RestrevapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
