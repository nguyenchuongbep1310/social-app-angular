import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ImageService } from 'src/_services/image.service';
import jwt_decode from 'jwt-decode';
import { PostService } from './post.service';

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

  baseUrl = 'https://localhost:44371/api/';

  constructor(
    private http: HttpClient,
    public imageService: ImageService,
    public postService: PostService
  ) {}

  // login(model: any){
  //   return this.http.post(this.baseUrl + 'account/login', model);
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

  public getProfile(profile) {
    this.imageService.getProfileInfo(this.tokenInfo.nameid).subscribe(
      (response) => {
        profile.userId = response.userId;
        profile.username = this.userName;
        profile.firstName = response.firstName;
        profile.lastName = response.lastName;
        profile.dateOfBirth = response.dateOfBirth;
        profile.gender = response.gender;
        profile.email = response.email;
        if (!response.phone) {
          profile.phone = '';
        } else {
          profile.phone = response.phone;
        }
        if (response.avatar) {
          profile.avatar = 'https://localhost:44371/images/' + response.avatar;
        } else {
          profile.avatar =
            'https://media.istockphoto.com/vectors/default-profile-picture-avatar-photo-placeholder-vector-illustration-vector-id1223671392?k=20&m=1223671392&s=612x612&w=0&h=lGpj2vWAI3WUT1JeJWm1PRoHT3V15_1pdcTn2szdwQ0=';
        }

        if (response.coverPhoto) {
          profile.coverPhoto =
            'https://localhost:44371/images/' + response.coverPhoto;
        } else {
          profile.coverPhoto =
            'https://s3.amazonaws.com/export.easil.com/4ffc1b2d-5384-404e-bcf9-e77f388b1f46/798e7a925e22c21006.png';
        }
      },
      (error) => console.log(error)
    );
  }

  public getPosts(profile, posts) {
    this.imageService.getProfileInfo(this.tokenInfo.nameid).subscribe(
      (response) => {
        profile.userId = response.userId;
        profile.username = this.userName;
        profile.firstName = response.firstName;
        profile.lastName = response.lastName;
        profile.dateOfBirth = response.dateOfBirth;
        profile.gender = response.gender;
        profile.email = response.email;
        if (!response.phone) {
          profile.phone = '';
        } else {
          profile.phone = response.phone;
        }
        if (response.avatar) {
          profile.avatar = 'https://localhost:44371/images/' + response.avatar;
        } else {
          profile.avatar =
            'https://media.istockphoto.com/vectors/default-profile-picture-avatar-photo-placeholder-vector-illustration-vector-id1223671392?k=20&m=1223671392&s=612x612&w=0&h=lGpj2vWAI3WUT1JeJWm1PRoHT3V15_1pdcTn2szdwQ0=';
        }

        if (response.coverPhoto) {
          profile.coverPhoto =
            'https://localhost:44371/images/' + response.coverPhoto;
        } else {
          profile.coverPhoto =
            'https://s3.amazonaws.com/export.easil.com/4ffc1b2d-5384-404e-bcf9-e77f388b1f46/798e7a925e22c21006.png';
        }
        this.postService.getPosts(response.userId, posts);
      },
      (error) => console.log(error)
    );
  }

  public login(model: any) {
    const url = `${this.baseUrl + 'account/login'}`;
    return this.http.post<any>(url, model, this.httpOptions);
  }

  public register(model: any) {
    const url = `${this.baseUrl + 'Account/register'}`;

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
    const url = `${this.baseUrl + 'Account/edit-profile'}`;

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
    const url = `${this.baseUrl + 'Account/search-user-profile'}`;

    let queryParams = new HttpParams();
    queryParams = queryParams.append("username", username);

    return this.http.get<any>(url, {params: queryParams});
  }

  public getPostSearchUser(userId: number): any {
   const url = `${this.baseUrl + 'Post'}`;

   let queryParams = new HttpParams();
    queryParams = queryParams.append("UserId", userId);

    return this.http.get<any>(url, {params: queryParams});
  }
}
