import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResultStatus } from '../models/resultStatus.model';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private http: HttpClient) { }
    
  getCityList(countryId: number){
    let param : string = "?countryId="+countryId;
    let url: string = environment.apiEndpoint + "/city" + param;

    return this.http.get<ResultStatus<any>>(
      url
    );
  }

  
}
