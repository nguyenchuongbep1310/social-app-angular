import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ImageService {
  private httpOptions = {
    headers: new HttpHeaders({}),
  };

  baseUrl = 'https://localhost:44371/api/';

  constructor(private http: HttpClient) {}

  public getProfileInfo(username: string) {
    const url = `${this.baseUrl + 'Account/user-profile'}`;
    const formData: any = new FormData();
    formData.append('username', username);
    return this.http.post<any>(url, formData, this.httpOptions);
  }
}
