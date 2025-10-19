import { Component } from '@angular/core';
import { customer } from 'src/modules/models';
import { ShareDataService } from '../services/share-data/share-data.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent {
  customer=<customer>{};
  

constructor(private shareDataService:ShareDataService){
}
  saveData(){
    if(this.customer.id !=undefined)
    this.shareDataService.data;
    this.shareDataService.onAdd(this.customer);
    this.customer=<customer>{};
   }
}
