import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ImageService } from './image.service';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
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
    return this.http.get<any>(url).subscribe((response) => {
      posts.posts = response;
    });
  }
}
