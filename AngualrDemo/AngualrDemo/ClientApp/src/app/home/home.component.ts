import { Component,OnInit } from '@angular/core';
import { customer } from 'src/modules/models';
import mock from 'src/mock-data/mock.json';
import { ShareDataService } from '../services/share-data/share-data.service';
import { WebServiceService } from '../services/web-services/web-service.service';

@Component({
  styleUrls:['./home.component.css'],
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  customers: customer[]=[];
  customer:customer=<customer>{};//{id:0, name:'',address:''};
  id:number=0;
  name:string='';
  address:string='';
  webData:any;
  websiteList: any = ['Javatpoint.com', 'HDTuto.com', 'Tutorialandexample.com'] ;

  constructor(private shareDataService:ShareDataService,private webServiceService:WebServiceService){

    shareDataService.newCustomer.subscribe(data=>{
      this.customers.push(data);      
      this.postWebservice(data);
    })
  
  }

  ngOnInit(): void {
    this.customers = mock;
    //this.callWebService();
  }

  saveData(){
   /*let cust:customer={
    id:this.id,
    name:this.name,
    address:this.address
   }
   if(this.customer.id !=undefined)
   this.customers.push(this.customer);
   this.customer=<customer>{};*/
   this.callWebService();
  }

  callWebService(){
    this.webServiceService.getDataFromService().subscribe(resp=>
      this.webData=resp
      );
  }

  postWebservice(data:any){
    this.webServiceService.postDataService(data).subscribe(resp=>
      this.webData=resp
      );
  }
}
