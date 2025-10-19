import { TestBed } from '@angular/core/testing';

import { ShareDataService } from './share-data.service';
import { customer } from 'src/modules/models';
import { cursorTo } from 'readline';

describe('ShareDataService', () => {
  let service: ShareDataService; 
  let customer:customer=<customer>{id:1, name:'saifu', address:'attar'};

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShareDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Add Data to service',()=>{
    service.onAdd(customer);

    service.newCustomer.subscribe(res=>{
      expect(res).toBe(customer);
    })
  });
});
