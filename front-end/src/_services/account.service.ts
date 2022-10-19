import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ImageService } from 'src/_services/image.service';
import jwt_decode from 'jwt-decode';
import { PostService } from './post.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  private httpOptions2 = {
    headers: new HttpHeaders({
      // 'Content-Type': 'multipart/form-data; boundary=<calculated when request is sent>',
      Authorization: 'Bearer ' + localStorage.getItem('token'),
    }),
  };

  constructor(
    private http: HttpClient,
    public imageService: ImageService,
    public postService: PostService
  ) {}

  // login(model: any){
  //   return this.http.post(environment.baseUrl + 'account/login', model);
  // }

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

  get name(): string {
    return this.tokenInfo && this.tokenInfo.name;
  }
  get familyName(): string {
    return this.tokenInfo && this.tokenInfo.family_name;
  }

  get fullname(): string {
    return this.tokenInfo && this.name + ' ' + this.familyName;
  }

  get email(): string {
    return this.tokenInfo && this.tokenInfo.email;
  }

  get userName(): string {
    return this.tokenInfo && this.tokenInfo.nameid;
  }

  get birthDay(): string {
    return this.tokenInfo && this.tokenInfo.birthdate;
  }

  get phone(): string {
    return this.tokenInfo && this.tokenInfo.Phone;
  }

  get gender(): string {
    return this.tokenInfo && this.tokenInfo.gender;
  }

  public getCurrentUserProfile() {
    return this.imageService.getProfileInfo(this.tokenInfo.nameid);
  }

  getUserProfileByUserId(userId) {
    const url = environment.baseUrl + 'Users/' + userId;

    return this.http.get(url, this.httpOptions2);
  }

  public login(model: any) {
    const url = `${environment.baseUrl + 'account/login'}`;
    return this.http.post<any>(url, model, this.httpOptions);
  }

  public register(model: any) {
    const url = `${environment.baseUrl + 'Account/register'}`;

    var formData: any = new FormData();
    formData.append('username', model.username);
    formData.append('password', model.password);
    formData.append('confirmPassword', model.confirmPassword);
    formData.append('firstName', model.firstName);
    formData.append('lastName', model.lastName);
    formData.append('email', model.email);
    formData.append('dateOfBirth', model.dateOfBirth);
    formData.append('gender', model.gender);
    formData.append('phone', model.phone);
    formData.append('avatar', model.avatar);

    return this.http.post<any>(url, formData, this.httpOptions2);
  }

  public editProfile(model: any) {
    const url = `${environment.baseUrl + 'Account/edit-profile'}`;

    var formData: any = new FormData();
    formData.append('username', model.username);
    formData.append('firstName', model.firstName);
    formData.append('lastName', model.lastName);
    formData.append('email', model.email);
    formData.append('phone', model.phone);
    formData.append('dateOfBirth', model.dateOfBirth);
    formData.append('gender', model.gender);
    formData.append('avatar', model.avatar);
    formData.append('coverPhoto', model.coverPhoto);

    return this.http.patch<any>(url, formData, this.httpOptions2);
  }

  public getProfileInfo(username: string): any {
    const url = `${environment.baseUrl + 'Account/search-user-profile'}`;

    let queryParams = new HttpParams();
    queryParams = queryParams.append('username', username);

    return this.http.get<any>(url, { params: queryParams });
  }

  public getPostSearchUser(userId: number): any {
    const url = `${environment.baseUrl + 'Post'}`;

    let queryParams = new HttpParams();
    queryParams = queryParams.append('UserId', userId);

    return this.http.get<any>(url, { params: queryParams });
  }
}
