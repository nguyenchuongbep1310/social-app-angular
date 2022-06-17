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

  get tokenInfo(): { name: string, family_name: string, email: string, nameid:string, birthdate:string } {
    const token = localStorage.getItem('token');
    if (token) {
      //parse token 
      // get username
      // return username

      var decoded: { name: string, family_name: string, email: string, nameid:string, birthdate:string } = jwt_decode(token);
      console.log(decoded.name);
      console.log(decoded.family_name);

      return decoded;
    }
    return null;
  }

  get lastName(): string {
    return this.tokenInfo && this.tokenInfo.name + " " + this.tokenInfo.family_name;
  }

  get email(): string {
    return this.tokenInfo && this.tokenInfo.email;
  }

  get userName(): string {
    return this.tokenInfo && this.tokenInfo.nameid;
  }

  get birthDay(): string {
    return this.tokenInfo && this.tokenInfo.birthdate;
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
