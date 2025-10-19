import { Component, Input } from '@angular/core';
import { login } from 'src/modules/models';
import { Injectable,Inject } from '@angular/core';
import { HttpClient,HttpClientModule } from '@angular/common/http';
import { map, Observable} from 'rxjs';
import { ShareDataService } from './services/share-data/share-data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  login=<login>{};
   isLoggined:boolean=false;

   private url:any;
   constructor(private http:HttpClient,private shareDataService:ShareDataService,  @Inject('BASE_URL') baseUrl: string) { 
     this.url = baseUrl;
   }

  Login()
  {
    if(this.login.userName!=null){
      this.isLoggined=true;
      this.postLoginData(this.login);
      this.shareDataService.data="dsfsd";
      console.log(this.login.userName +'loggined');
    }
  }

  postLoginData(data:any){    
    return this.http.post<any>(this.url + 'weatherforecast/testPost',data)
    .pipe(map(res=>res)).subscribe();
  }
}
