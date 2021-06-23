import { TestBed } from '@angular/core/testing';
import { HttpClientModule } from "@angular/common/http";
import { HttpClientTestingModule} from "@angular/common/http/testing";

import { AppService } from './app.service';

describe('AppService', () => {
  let service: AppService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, HttpClientTestingModule],
    });
    service = TestBed.inject(AppService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});