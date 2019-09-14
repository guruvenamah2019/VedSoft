import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RequestModel, ResponseModel, ResultModel, SearchRequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { CUSTOMER_ROLE_SERVICE_URL } from "../constant/service-url";
import { AuthenticationService } from './authentication.service';
import { map, tap } from 'rxjs/operators';
import { UserRoleModel } from '../models/master-model';

@Injectable({
    providedIn: 'root'
})
export class UserRoleService {

    private roleList: UserRoleModel[] = [];

    public get RoleList(){
        return this.roleList;
    }

    constructor(private http: HttpClient, public baseService: BaseService, public userSerice: AuthenticationService) {

    }

    public addUserRole(course: UserRoleModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<UserRoleModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${CUSTOMER_ROLE_SERVICE_URL.ACTION_ADD_CUSTOMER_ROLE}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.roleList = [];
        }));

    }
    public updateUserRole(course: UserRoleModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<UserRoleModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${CUSTOMER_ROLE_SERVICE_URL.ACTION_UPDATE_CUSTOMER_ROLE}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.roleList = [];
        }));

    }
    public getUserRole(input: SearchRequestModel<UserRoleModel>): Observable<UserRoleModel[]> {

        this.roleList.push({
            id:1,
            name:"Admin",
        });
        this.roleList.push({
            id:2,
            name:"User",
        });
        this.roleList.push({
            id:3,
            name:"Accountant",
        });
        this.roleList.push({
            id:4,
            name:"Super Admin",
        });
        this.roleList.push({
            id:5,
            name:"Admin 2",
        });
        this.roleList.push({
            id:6,
            name:"Admin 2",
        });

        if (this.roleList != null && this.roleList.length > 0) {
            return of(this.roleList)
        }
        else {
            let url = `${this.baseService.appInfo.apiUrl}/${CUSTOMER_ROLE_SERVICE_URL.ACTION_GET_CUSTOMER_ROLE}`;
            return this.http.post<ResponseModel<UserRoleModel[]>>(url, input).pipe(
                map((data: ResponseModel<UserRoleModel[]>) => {
                    if (data != null && data.responseData != null) {
                        this.roleList = data.responseData;
                    }
                    return this.roleList;
                })
            );

        }
    }
    public makeInActiveUserRole(input: RequestModel<UserRoleModel>): Observable<ResponseModel<ResultModel>> {

        let url = `${this.baseService.appInfo.apiUrl}/${CUSTOMER_ROLE_SERVICE_URL.ACTION_MAKE_INACTIVE_CUSTOMER_ROLE}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.roleList = [];
        }));

    }
   


}
