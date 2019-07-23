import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, mapTo, tap } from 'rxjs/operators';
import { TokenModel, RequestModel, ResponseModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { LoginRequestModel, AuthenticationModel, UserMasterModel, LoginResponseModel } from '../models/user-model';
import { LOGIN_SERVICE_URL } from "../constant/service-url";
import { post } from 'selenium-webdriver/http';
import { LoginStatusEnum } from '../enums/login-status.enum';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private readonly JWT_TOKEN = 'JWT_TOKEN';
  private readonly REFRESH_TOKEN = 'REFRESH_TOKEN';
  public loggedUser: UserMasterModel;

  constructor(private http: HttpClient, private baseService: BaseService) {

  }

  public login(user: LoginRequestModel): Observable<ResponseModel<AuthenticationModel>> {

    let input: RequestModel<LoginRequestModel> = {
      CustomerId: this.baseService.appInfo.CustomerId,
      LanguageId: this.baseService.appInfo.LanguageId,
      requestParameter: user
    };

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

  public logout() {
    let url = `${this.baseService.appInfo.apiUrl}/users/logout`;
    return this.http.post<any>(url, {
      'refreshToken': this.getRefreshToken()
    }).pipe(
      tap(() => this.doLogoutUser()),
      mapTo(true),
      catchError(error => {
        alert(error.error);
        return of(false);
      }));
  }

  public isLoggedIn() {
    return !!this.getJwtToken();
  }

  public refreshToken() {
    let url = `${this.baseService.appInfo.apiUrl}/users/logout`;
    return this.http.post<any>(url, {
      'refreshToken': this.getRefreshToken()
    }).pipe(tap((tokens: TokenModel) => {
      this.storeJwtToken(tokens.jwt);
    }));
  }

  public getJwtToken() {
    return localStorage.getItem(this.JWT_TOKEN);
  }

  private doLoginUser(user: AuthenticationModel) {
    if (user.loginResponseDetails != null && user.loginResponseDetails.loginStatus == LoginStatusEnum.Success) {
      this.loggedUser = user.userDetails;
      this.storeTokens(user.loginResponseDetails);
    }
  }

  private doLogoutUser() {
    this.loggedUser = null;
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
}
