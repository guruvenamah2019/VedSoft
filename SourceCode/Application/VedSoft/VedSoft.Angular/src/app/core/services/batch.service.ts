import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RequestModel, ResponseModel, ResultModel, SearchRequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { BANK_SERVICE_URL } from "../constant/service-url";
import { BankModel } from '../models/master-model';
import { map, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class BatchService {

    private _bankList: BankModel[] = [];

    public get BankList(){
        return this._bankList;
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

    public addBank(course: BankModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<BankModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${BANK_SERVICE_URL.ACTION_ADD_BANK}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._bankList = [];
        }));

    }
    public updateBank(course: BankModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<BankModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${BANK_SERVICE_URL.ACTION_UPDATE_BANK}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._bankList = [];
        }));

    }
    public getBank(input: SearchRequestModel<BankModel>): Observable<BankModel[]> {

        

        if (this._bankList != null && this._bankList.length > 0) {
            return of(this._bankList)
        }
        else {
            let url = `${this.baseService.appInfo.apiUrl}/${BANK_SERVICE_URL.ACTION_GET_BANK}`;
            return this.http.post<ResponseModel<BankModel[]>>(url, input).pipe(
                map((data: ResponseModel<BankModel[]>) => {
                    if (data != null && data.responseData != null) {
                        this._bankList = data.responseData;


                    }
                    return this._bankList;
                })
            );

        }
    }
    public makeInActiveBank(input: RequestModel<BankModel>): Observable<ResponseModel<ResultModel>> {

        let url = `${this.baseService.appInfo.apiUrl}/${BANK_SERVICE_URL.ACTION_MAKE_INACTIVE_BANK}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._bankList = [];
        }));

    }
    


}
