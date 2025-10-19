import { Component } from '@angular/core';
import { login } from 'src/modules/models';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  isLoggined:boolean=false;
  login=<login>{};

  Login()
  {
    if(this.login.userName!=null){
      this.isLoggined=true;
      console.log(this.login.userName +'loggined');
    }
  }
}
