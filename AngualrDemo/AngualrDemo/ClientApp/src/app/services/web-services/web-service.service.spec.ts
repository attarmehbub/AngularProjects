import { TestBed } from '@angular/core/testing';

import { WebServiceService } from './web-service.service';
import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('WebServiceService', () => {
  let service: WebServiceService;
  let data:any;

  beforeEach(() => {
    TestBed.configureTestingModule({
     imports: [HttpClientTestingModule],
      providers: [
        { provide: 'BASE_URL', useValue: 'http://localhost:9876/' },
        WebServiceService,
        HttpClient
      ]
    });
    service = TestBed.inject(WebServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('check data from service',()=>{
    service.getDataFromService().subscribe(res=>{
      expect(res).toBe(data);
    });
  });
});
