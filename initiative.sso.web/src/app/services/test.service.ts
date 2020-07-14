import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  apiEndpoint: string;

  constructor(private http: HttpClient) { 
    this.apiEndpoint = environment.api_url;
  }

  TestAPI(){
    return this.http.get<any>(this.apiEndpoint + "/api/company");
  }
}
