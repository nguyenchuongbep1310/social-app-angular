import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import jwt_decode from "jwt-decode";
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  }

  //baseUrl = 'https://localhost:44371/api/'

  
  
  constructor(private http: HttpClient) { }

  // login(model: any){
  //   return this.http.post(this.baseUrl + 'account/login', model);

  // }

  get userName(): string {
    const token = localStorage.getItem('token');
    if (token) {
      //parse token 
      // get username
      // return username
      
      var decoded: {nameid: string} = jwt_decode(token);
      console.log(decoded.nameid); 

      return decoded.nameid;
    }
    return '';
  }
  
  public login(model: any) {
    const url = `${environment.baseUrl + 'account/login'}`;
    return this.http.post<any>(url, model, this.httpOptions)
  }

  public register(model: any) {
    const url = `${environment.baseUrl + 'Account/register'}`;
    return this.http.post<any>(url, model, this.httpOptions)
  }
}
