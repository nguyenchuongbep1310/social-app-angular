import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from  '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  }

  baseUrl = 'https://localhost:44371/api/'

  constructor(private http: HttpClient) { }

  // login(model: any){
  //   return this.http.post(this.baseUrl + 'account/login', model);
    
  // }

  public login(model: any) {
    const url = `${this.baseUrl + 'account/login'}`;
    return this.http.post<any>(url, model, this.httpOptions)
  }

  public register(model: any) {
    const url = `${this.baseUrl + 'Account/register'}`;
    return this.http.post<any>(url, model, this.httpOptions)
  }
}
