import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RequestModel, ResponseModel, ResultModel, SearchRequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import {  ACADEMIC_YEAR_SERVICE_URL } from "../constant/service-url";
import { AcademicYearModel } from '../models/master-model';
import { map, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AcademicYearService {

    private _acadmicYearList: AcademicYearModel[] = [];

    public get AcademicYearList(){
        return this._acadmicYearList;
    }

    constructor(private http: HttpClient, public baseService: BaseService) {
/*
        this._bankList.push({
            id:1,
            name:"SBI",
        });
        this._bankList.push({
            id:2,
            name:"ICICI",
        });
        this._bankList.push({
            id:3,
            name:"HDFC",
        });
        this._bankList.push({
            id:4,
            name:"AXIS",
        });
  */    

    }

    public addAcademicYear(course: AcademicYearModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<AcademicYearModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${ACADEMIC_YEAR_SERVICE_URL.ACTION_ADD_ACADEMIC_YEAR}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._acadmicYearList = [];
        }));

    }
    public updateAcademicYear(course: AcademicYearModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<AcademicYearModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${ACADEMIC_YEAR_SERVICE_URL.ACTION_UPDATE_ACADEMIC_YEAR}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._acadmicYearList = [];
        }));

    }
    public getAcademicYear(input: SearchRequestModel<AcademicYearModel>): Observable<AcademicYearModel[]> {

        

        if (this._acadmicYearList != null && this._acadmicYearList.length > 0) {
            return of(this._acadmicYearList)
        }
        else {
            let url = `${this.baseService.appInfo.apiUrl}/${ACADEMIC_YEAR_SERVICE_URL.ACTION_GET_ACADEMIC_YEAR}`;
            return this.http.post<ResponseModel<AcademicYearModel[]>>(url, input).pipe(
                map((data: ResponseModel<AcademicYearModel[]>) => {
                    if (data != null && data.responseData != null) {
                        this._acadmicYearList = data.responseData;


                    }
                    return this._acadmicYearList;
                })
            );

        }
    }
    public makeInActiveAcademicYear(input: RequestModel<AcademicYearModel>): Observable<ResponseModel<ResultModel>> {

        let url = `${this.baseService.appInfo.apiUrl}/${ACADEMIC_YEAR_SERVICE_URL.ACTION_MAKE_INACTIVE_ACADEMIC_YEAR}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._acadmicYearList = [];
        }));

    }
    


}
