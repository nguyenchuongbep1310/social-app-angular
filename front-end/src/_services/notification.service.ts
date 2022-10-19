import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(private http: HttpClient) {}

  baseUrl = 'https://localhost:44371/api/Notifications/';

  getNotificationCount(userId) {
    const url = `${this.baseUrl}notificationcount?userId=${userId}`;
    return this.http.get(url);
  }

  getNotificationResult(userId) {
    const url = `${this.baseUrl}notificationresult?userId=${userId}`;
    return this.http.get(url);
  }

  deleteNotifications(userId) {
    const url = `${this.baseUrl}deletenotifications?userId=${userId}`;
    return this.http.delete(url, {headers: new HttpHeaders({
      Authorization: 'Bearer ' + localStorage.getItem('token'),})});
  }
}
