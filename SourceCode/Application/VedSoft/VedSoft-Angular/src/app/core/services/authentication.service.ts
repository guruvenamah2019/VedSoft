import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, mapTo, tap } from 'rxjs/operators';
import { TokenModel, RequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { LoginRequestModel } from '../models/user-model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private readonly JWT_TOKEN = 'JWT_TOKEN';
  private readonly REFRESH_TOKEN = 'REFRESH_TOKEN';
  private loggedUser: string;

  constructor(private http: HttpClient, private baseService: BaseService) {

  }

  public login(user: LoginRequestModel): Observable<boolean> {

    let input: RequestModel<LoginRequestModel> = {
      CustomerID: this.baseService.appInfo.CustomerId,
      RequestParameter: user
    };

    let url = `${this.baseService.appInfo.apiUrl}/users/authenticate`;

    return this.http.post<any>(url, user)
      .pipe(
        tap(tokens => this.doLoginUser(user.Username, tokens)),
        mapTo(true),
        catchError(error => {
          console.log( JSON.stringify( error.error));
          return of(false);
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

  private doLoginUser(username: string, tokens: TokenModel) {
    this.loggedUser = username;
    this.storeTokens(tokens);
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

  private storeTokens(tokens: TokenModel) {
    localStorage.setItem(this.JWT_TOKEN, tokens.jwt);
    localStorage.setItem(this.REFRESH_TOKEN, tokens.refreshToken);
  }

  private removeTokens() {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.REFRESH_TOKEN);
  }
}
