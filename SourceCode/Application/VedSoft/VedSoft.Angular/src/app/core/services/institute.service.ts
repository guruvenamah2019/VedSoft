import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RequestModel, ResponseModel, ResultModel, SearchRequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { INSTITUTE_SERVICE_URL } from "../constant/service-url";
import { InstituteModel } from '../models/master-model';
import { map, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class InstituteService {

    private _instituteList: InstituteModel[] = [];

    public get InstituteList(){
        return this._instituteList;
    }

    constructor(private http: HttpClient, public baseService: BaseService) {
/*
        this._instituteList.push({
            id:1,
            name:"DAVV Indore",
            type:1
        });
        this._instituteList.push({
            id:2,
            name:"School of computer",
            type:1
        });
        this._instituteList.push({
            id:3,
            name:"DPS",
            type:1
        });
        this._instituteList.push({
            id:4,
            name:"IPS",
            type:1
        });
  */    

    }

    public addInstitute(course: InstituteModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<InstituteModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${INSTITUTE_SERVICE_URL.ACTION_ADD_INSTITUTE}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._instituteList = [];
        }));

    }
    public updateInstitute(course: InstituteModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<InstituteModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${INSTITUTE_SERVICE_URL.ACTION_UPDATE_INSTITUTE}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._instituteList = [];
        }));

    }
    public getInstitute(input: SearchRequestModel<InstituteModel>): Observable<InstituteModel[]> {

        

        if (this._instituteList != null && this._instituteList.length > 0) {
            return of(this._instituteList)
        }
        else {
            let url = `${this.baseService.appInfo.apiUrl}/${INSTITUTE_SERVICE_URL.ACTION_GET_INSTITUTE}`;
            return this.http.post<ResponseModel<InstituteModel[]>>(url, input).pipe(
                map((data: ResponseModel<InstituteModel[]>) => {
                    if (data != null && data.responseData != null) {
                        this._instituteList = data.responseData;


                    }
                    return this._instituteList;
                })
            );

        }
    }
    public makeInActiveInstitute(input: RequestModel<InstituteModel>): Observable<ResponseModel<ResultModel>> {

        let url = `${this.baseService.appInfo.apiUrl}/${INSTITUTE_SERVICE_URL.ACTION_MAKE_INACTIVE_INSTITUTE}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._instituteList = [];
        }));

    }
    


}
