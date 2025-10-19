import { Component } from '@angular/core';

@Component({
  selector: 'app-data-binding-types',
  templateUrl: './data-binding-types.component.html',
  styleUrls: ['./data-binding-types.component.css']
})
export class DataBindingTypesComponent {

  componentName:string= "app-data-binding-type";
  imgUrl="https://static.javatpoint.com/tutorial/angular7/images/angular-7-logo.png";  
  fullName="Testing two way data binding";

  onSave($event:any){
    this.componentName="Test";
  }
}
