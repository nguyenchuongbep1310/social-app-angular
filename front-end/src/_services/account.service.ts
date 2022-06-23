import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import jwt_decode from 'jwt-decode';
@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  baseUrl = 'https://localhost:44371/api/';

  constructor(private http: HttpClient) {}

  // login(model: any){
  //   return this.http.post(this.baseUrl + 'account/login', model);

  // }

  get tokenInfo(): {
    name: string;
    family_name: string;
    email: string;
    nameid: string;
    birthdate: string;
    Phone: string;
    gender: string;
  } {
    const token = localStorage.getItem('token');
    if (token) {
      //parse token
      // get username
      // return username
      var decoded: {
        name: string;
        family_name: string;
        email: string;
        nameid: string;
        birthdate: string;
        Phone: string;
        gender: string;
      } = jwt_decode(token);

      // console.log(decoded.name);
      // console.log(decoded.family_name);

      return decoded;
    }
    return null;
  }

  get name(): string {
    return this.tokenInfo && this.tokenInfo.name;
  }
  get familyName(): string {
    return this.tokenInfo && this.tokenInfo.family_name;
  }

  get fullname(): string {
    return this.tokenInfo && this.name + ' ' + this.familyName;
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

  get phone(): string {
    return this.tokenInfo && this.tokenInfo.Phone;
  }

  get gender(): string {
    return this.tokenInfo && this.tokenInfo.gender;
  }

  public login(model: any) {
    const url = `${this.baseUrl + 'account/login'}`;
    return this.http.post<any>(url, model, this.httpOptions);
  }

  public register(model: any) {
    const url = `${this.baseUrl + 'Account/register'}`;
    return this.http.post<any>(url, model, this.httpOptions);
  }

  public editProfile(model: any) {
    const url = `${this.baseUrl + '/api/Account/edit-profile'}`;
    return this.http.post<any>(url, model, this.httpOptions);
  }

  public getUserProfile(username: string) {
    const url = `${this.baseUrl + '/api/Account/user-profile'}`;
    return this.http.get<any>(url);
  }
}
