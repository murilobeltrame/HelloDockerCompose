import { TestBed, inject } from '@angular/core/testing';

import { TodoApiService } from './todo-api.service';

describe('TodoApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TodoApiService]
    });
  });

  it('should be created', inject([TodoApiService], (service: TodoApiService) => {
    expect(service).toBeTruthy();
  }));
});
