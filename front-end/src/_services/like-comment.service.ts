import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class LikeCommentService {
  constructor(private http: HttpClient) {}

  baseUrl = 'https://localhost:44371/api/';

  public postLike(currentUserId, postId) {
    const url = this.baseUrl + 'Likes';

    const formData = new FormData();
    formData.append('userId', currentUserId);
    formData.append('postId', postId);

    return this.http.post<any>(url, formData, {
      headers: new HttpHeaders({
        'Content-type': 'application/json',
      }),
    });
  }

  public patchLike(likeId, postId, userId) {
    const url = this.baseUrl + 'Likes';

    const formData = new FormData();
    formData.append('id', likeId);
    formData.append('postId', postId);
    formData.append('userId', userId);

    return this.http.patch<any>(url, formData);
  }

  public countLikes(postId) {
    const url = this.baseUrl + 'Post/' + postId + '/CountLikes';

    return this.http.get(url);
  }
}
