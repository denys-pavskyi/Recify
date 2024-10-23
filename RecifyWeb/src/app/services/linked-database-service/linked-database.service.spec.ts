import { TestBed } from '@angular/core/testing';

import { LinkedDatabaseService } from '../linked-database-service/linked-database.service';

describe('LinkedDatabaseServiceService', () => {
  let service: LinkedDatabaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LinkedDatabaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
