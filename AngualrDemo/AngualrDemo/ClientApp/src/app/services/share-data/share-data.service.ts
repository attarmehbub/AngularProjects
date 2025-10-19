import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { customer } from 'src/modules/models';

@Injectable({
  providedIn: 'root'
})

export class ShareDataService {
  public data: any="attar";
  private customerAdd = new BehaviorSubject<any>('');

  newCustomer = this.customerAdd.asObservable();

  constructor() { }

  onAdd(customer: customer) {
    this.customerAdd.next(customer);
  }
}
