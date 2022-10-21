import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

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

  public addFriend(username: string) {
    return this.http.post(environment.baseUrl + '/' + username, {}, httpOptions);
  }

  public unFriend(username: string) {
    return this.http.delete(environment.baseUrl + '/' + username, httpOptions);
  }

  public getFriend(sourceUserId: number, likedUserId: number) {
    return this.http.get(
      environment.baseUrl + `?sourceUserId=${sourceUserId}&likedUserId=${likedUserId}`
    );
  }
}
