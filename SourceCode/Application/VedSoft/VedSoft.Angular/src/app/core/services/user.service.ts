import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service'
import { UserBaseModel } from '../models/user-model/index';


@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient, private _base:BaseService) { }

    getAll() {
        return this.http.get<UserBaseModel[]>(`${this._base.appInfo.apiUrl}/users`);
    }
}