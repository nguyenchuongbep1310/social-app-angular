import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(private http: HttpClient) {}

  getNotificationCount(userId) {
    const url = `${environment.baseUrl}notificationcount?userId=${userId}`;
    return this.http.get(url);
  }

  getNotificationResult(userId) {
    const url = `${environment.baseUrl}notificationresult?userId=${userId}`;
    return this.http.get(url);
  }

  deleteNotifications(userId) {
    const url = `${environment.baseUrl}deletenotifications?userId=${userId}`;
    return this.http.delete(url, {headers: new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),})});
  }
}
