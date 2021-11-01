import { TestBed } from '@angular/core/testing';

import { SystemManagementService } from './system-management.service';

describe('SystemManagementService', () => {
  let service: SystemManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SystemManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
