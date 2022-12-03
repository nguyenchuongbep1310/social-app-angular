import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token'),
  }),
};

@Injectable({
  providedIn: 'root',
})
export class FriendService {
  constructor(private http: HttpClient) {}

  baseUrl = 'http://20.244.58.242/api/Friend';

  public addFriend(username: string) {
    return this.http.post(this.baseUrl + '/' + username, {}, httpOptions);
  }

  public unFriend(username: string) {
    return this.http.delete(this.baseUrl + '/' + username, httpOptions);
  }

  public getFriend(sourceUserId: number, likedUserId: number) {
    return this.http.get(
      this.baseUrl + `?sourceUserId=${sourceUserId}&likedUserId=${likedUserId}`
    );
  }
}
