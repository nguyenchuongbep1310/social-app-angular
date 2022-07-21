import { HttpClient } from '@angular/common/http';
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
}
