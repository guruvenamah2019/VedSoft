import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, mapTo, tap, map } from 'rxjs/operators';
import { TokenModel, RequestModel, ResponseModel, ResultModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { LoginRequestModel, AuthenticationModel, UserLoginModel, LoginResponseModel } from '../models/login';
import { LOGIN_SERVICE_URL } from "../constant/service-url";
import { post } from 'selenium-webdriver/http';
import { LoginStatusEnum } from '../enums/login-status.enum';
import { SetPasswordRequestModel } from '../models/login';
import { CustomerModel } from '../models/master-model/customer-model';
import { CustomerBranchModel } from '../models/master-model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private readonly JWT_TOKEN = 'JWT_TOKEN';
  private readonly REFRESH_TOKEN = 'REFRESH_TOKEN';

  constructor(private http: HttpClient, public baseService: BaseService) {

  }
  public get loggedUser(): UserLoginModel {
    return this.baseService.loggedUser;
  }
  public set loggedUser(user: UserLoginModel) {
    this.baseService.loggedUser = user;
  }



  public login(user: LoginRequestModel): Observable<ResponseModel<AuthenticationModel>> {

    let input: RequestModel<LoginRequestModel> = this.baseService.getRequestModel(user);

    let url = `${this.baseService.appInfo.apiUrl}/${LOGIN_SERVICE_URL.AUTHENTICATE}`;

    return this.http.post<ResponseModel<AuthenticationModel>>(url, input)
      .pipe(
        tap(tokens => {
          if (tokens != null && tokens.responseData != null)
            this.doLoginUser(tokens.responseData)
        }),
        catchError(error => {
          alert(JSON.stringify(error.error));
          return of(null);
        }));
  }

  public logout(): Observable<ResponseModel<ResultModel>> {

    let input: RequestModel<LoginResponseModel> = this.baseService.getRequestModel({
      refreshToken: this.getRefreshToken(),
      token: this.getJwtToken()
    });


    let url = `${this.baseService.appInfo.apiUrl}/${LOGIN_SERVICE_URL.LOGOUT}`;
    return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(
      tap(() => this.doLogoutUser()),
      catchError(error => {
        alert(error.error);
        return of(null);
      }));
  }

  public isLoggedIn() {

    return !!this.getJwtToken();
  }

  public refreshToken(): Observable<ResponseModel<LoginResponseModel>> {
    //    let url = `${this.baseService.appInfo.apiUrl}/users/logout`;
    let url = `${this.baseService.appInfo.apiUrl}/${LOGIN_SERVICE_URL.REFRESH_TOKEN}`;

    let input: RequestModel<LoginResponseModel> = this.baseService.getRequestModel({
      refreshToken: this.getRefreshToken(),
      token: this.getJwtToken()
    })

    return this.http.post<ResponseModel<LoginResponseModel>>(url, input).pipe(tap((tokens: ResponseModel<LoginResponseModel>) => {
      if (tokens != null && tokens.responseData != null && tokens.responseData.loginStatus == LoginStatusEnum.Success) {
        this.storeJwtToken(tokens.responseData.token);
      }
      else {
        this.removeTokens();
        this.logout().subscribe(x => {
          location.reload(true);
        });

      }
    }));
  }

  public getJwtToken() {
    return localStorage.getItem(this.JWT_TOKEN);
  }

  private doLoginUser(user: AuthenticationModel) {
    if (user.loginResponseDetails != null && user.loginResponseDetails.loginStatus == LoginStatusEnum.Success) {
      this.loggedUser = user.userDetails;
      this.baseService.loggedUser = user.userDetails;
      this.storeTokens(user.loginResponseDetails);
    }
  }

  private doLogoutUser() {
    this.loggedUser = null;
    this.baseService.loggedUser = null;
    this.removeTokens();
  }

  private getRefreshToken() {
    return localStorage.getItem(this.REFRESH_TOKEN);
  }

  private storeJwtToken(jwt: string) {
    localStorage.setItem(this.JWT_TOKEN, jwt);
  }

  private storeTokens(tokens: LoginResponseModel) {
    localStorage.setItem(this.JWT_TOKEN, tokens.token);
    localStorage.setItem(this.REFRESH_TOKEN, tokens.refreshToken);
  }

  private removeTokens() {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.REFRESH_TOKEN);
  }

  public changePassword(user: SetPasswordRequestModel): Observable<ResponseModel<ResultModel>> {

    let input: RequestModel<SetPasswordRequestModel> = this.baseService.getRequestModel(user);

    let url = `${this.baseService.appInfo.apiUrl}/${LOGIN_SERVICE_URL.UPDATE_PASSWORD}`;

    return this.http.post<ResponseModel<ResultModel>>(url, input)
      .pipe(
        catchError(error => {
          return of(null);
        }));
  }

  private getUserDetailsByToken(): Observable<ResponseModel<UserLoginModel>> {

    //    let url = `${this.baseService.appInfo.apiUrl}/users/logout`;
    let url = `${this.baseService.appInfo.apiUrl}/${LOGIN_SERVICE_URL.USER_DETAILS_BY_TOKEN}`;

    let input: RequestModel<LoginResponseModel> = this.baseService.getRequestModel({
      refreshToken: this.getRefreshToken(),
      token: this.getJwtToken()
    });

    return this.http.post<ResponseModel<UserLoginModel>>(url, input).pipe();

  }

  public IsUserAuthenticate(): Observable<boolean> {
    /*
    this.loggedUser = {
      firstName:'Ram',
      id:1,
      lastName:'Patidar',
      middleName:'Ram',
      userName:'Ram',

    };
    */
    if (this.loggedUser != null && this.loggedUser.id > 0) {
      return of(true)
    }
    else {

      return this.getUserDetailsByToken().pipe(
        map((result: ResponseModel<UserLoginModel>) => {

          if (result != null && result.responseData != null) {
            this.loggedUser = result.responseData;
            this.baseService.loggedUser = result.responseData;
          }
          return this.baseService.loggedUser != null && this.baseService.loggedUser.id > 0
        }));

    }
  }
}
