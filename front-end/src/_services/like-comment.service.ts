import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

const headers = new HttpHeaders({
  Authorization: 'Bearer ' + localStorage.getItem('token'),
  'Content-type': 'application/json',
});

@Injectable({
  providedIn: 'root',
})
export class LikeCommentService {
  constructor(private http: HttpClient) {}

  baseUrl = 'https://localhost:44371/api/';

  public getLikeOfCurrentUser(currentUserId, postId) {
    const url = this.baseUrl + 'Likes';

    let queryParams = new HttpParams();
    queryParams = queryParams.append('UserId', currentUserId);
    queryParams = queryParams.append('PostId', postId);

    return this.http.get<any>(url, { params: queryParams });
  }

  public postLike(currentUserId, postId) {
    const url = this.baseUrl + 'Likes';

    const formData = new FormData();
    formData.append('userId', currentUserId);
    formData.append('postId', postId);

    return this.http.post<any>(url, formData, {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token'),})
    });
  }

  public deleteLike(likeId) {
    const url = this.baseUrl + 'Likes/' + likeId;
    return this.http.delete<any>(url, {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token'),})
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

  public getComments(postId) {
    const url = this.baseUrl + `Post/${postId}/GetComments`;

    return this.http.get<any>(url);
  }

  public postComment(text, userId, postId) {
    const url = this.baseUrl + 'Comments';

    return this.http.post<any>(url, { text, userId, postId }, {headers});
  }

  public deleteComment(id: number, userId: number) {
    const url = this.baseUrl + 'Comments';

    return this.http.delete(url, {
      headers,
      body: {
        id,
        userId,
      },
    });
  }
}
