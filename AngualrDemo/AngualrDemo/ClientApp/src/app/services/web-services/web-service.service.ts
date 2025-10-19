import { Injectable,Inject } from '@angular/core';
import { HttpClient,HttpClientModule } from '@angular/common/http';
import { map, Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WebServiceService {
 private url:any;
  constructor(private http:HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.url = baseUrl;
  }

  getDataFromService(){
   return this.http.get<any>(this.url + 'weatherforecast/test')
    .pipe(
      map(res=>res)
    )
  }

  postDataService(data:any){
    return this.http.post<any>(this.url + 'weatherforecast/testPost',data)
    .pipe(map(res=>res))
  }
}
