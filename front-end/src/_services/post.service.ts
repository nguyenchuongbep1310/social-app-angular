import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ImageService } from './image.service';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  private httpOptions = {
    headers: new HttpHeaders({}),
  };

  private httpOptions2 = {
    headers: new HttpHeaders({
      // 'Content-Type': 'multipart/form-data; boundary=<calculated when request is sent>',
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    }),
  };

  baseUrl = 'https://localhost:44371/api/';

  constructor(private http: HttpClient, public imageService: ImageService) {}

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
      var decoded: {
        name: string;
        family_name: string;
        email: string;
        nameid: string;
        birthdate: string;
        Phone: string;
        gender: string;
      } = jwt_decode(token);

      return decoded;
    }
    return null;
  }

  public getPosts(userId, posts) {
    const url = `${this.baseUrl + 'Post?userId=' + userId}`;
    return this.http.get<any>(url, this.httpOptions2).subscribe((response) => {
      posts.posts = response.reverse();
    });
  }

  public createPost(userId, text, images): any {
    if (!window.localStorage.getItem('token')) {
      window.location.reload();
      return;
    }
    const url = `${this.baseUrl + 'Post'}`;

    const formData: any = new FormData();
    formData.append('userId', userId);
    formData.append('text', text);
    formData.append('images', images);

    return this.http.post<any>(url, formData, this.httpOptions2);
  }
}
