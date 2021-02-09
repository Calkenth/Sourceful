import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '../models/IUser';
import { IUserDetail } from '../models/IUserDetail';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl = "https://localhost:5001/api/User/";
  private getUsersUrl = "GetUsers";
  private getUserDetailUrl = "GetUser/";
  private postNewUserUrl = "CreateUser";
  private deleteUserUrl = "DeleteUser/"

  private headers = new HttpHeaders({
    'Content-Type': 'application/json; charset=utf-8'
  });

  constructor(private HttpClient: HttpClient) { }

  getUsers(): Observable<IUser[]> {
    return this.HttpClient.get<IUser[]>(this.baseUrl + this.getUsersUrl).pipe();
  }

  getUserDetail(id: number): Observable<IUserDetail> {
    return this.HttpClient.get<IUserDetail>(this.baseUrl + this.getUserDetailUrl + id).pipe();
  }

  postNewUser(userDetail: IUserDetail): Observable<any> {
    return this.HttpClient.post<IUserDetail>(this.baseUrl + this.postNewUserUrl, userDetail, { headers: this.headers}).pipe();
  }

  deleteUser(id: number): Observable<any> {
    return this.HttpClient.delete(this.baseUrl + this.deleteUserUrl + id).pipe();
  }
}
