import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResultStatus } from '../models/resultStatus.model';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(private http: HttpClient) { }
    
  getCountryList(){
    let url: string = environment.apiEndpoint + "/country";
    let url2: string = "https://localhost:44361/country";
    console.log(url);
    console.log(url2);

    return this.http.get<ResultStatus<any>>(
      url
    );
  }

  
}
