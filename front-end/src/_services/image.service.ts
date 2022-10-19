import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ImageService {
  private httpOptions = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    }),
  };


  constructor(private http: HttpClient) {}

  public getProfileInfo(username: string): any {
    const url = `${environment.baseUrl + 'Account/user-profile'}`;
    const formData: any = new FormData();
    formData.append('username', username);
    return this.http.post<any>(url, formData, this.httpOptions);
  }
}
