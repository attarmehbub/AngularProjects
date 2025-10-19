import { Component,Output,EventEmitter } from '@angular/core';
import { login } from 'src/modules/models';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  isLoggined1:boolean=false;
  login=<login>{};
  @Output() islogginedOut=new EventEmitter<any>();

  Login()
  {
    if(this.login.userName!=null){
      this.isLoggined1=true;
      this.islogginedOut.emit(true);
      console.log(this.login.userName +'loggined');
    }
  }
}
