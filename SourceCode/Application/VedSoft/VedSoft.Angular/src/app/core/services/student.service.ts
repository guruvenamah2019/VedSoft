import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RequestModel, ResponseModel, ResultModel, SearchRequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { BANK_SERVICE_URL } from "../constant/service-url";
import { map, tap } from 'rxjs/operators';
import { StudentModel } from '../models/student-model/student-master.model';

@Injectable({
    providedIn: 'root'
})
export class StudentService {

    private _studentList: StudentModel[] = [];

    public get StudentList(){
        return this._studentList;
    }

    constructor(private http: HttpClient, public baseService: BaseService) {

        this._studentList.push({
            id:1,
            firstName:"Ram",

        });
        this._studentList.push({
            id:2,
            firstName:"Vijay",
        });
        this._studentList.push({
            id:3,
            firstName:"Dev",
        });
        this._studentList.push({
            id:4,
            firstName:"Karan",
        });
      

    }

    public addStudent(course: StudentModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<StudentModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${BANK_SERVICE_URL.ACTION_ADD_BANK}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._studentList = [];
        }));

    }
    public updateStudent(course: StudentModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<StudentModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${BANK_SERVICE_URL.ACTION_UPDATE_BANK}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._studentList = [];
        }));

    }
    public getStudent(input: SearchRequestModel<StudentModel>): Observable<StudentModel[]> {

        

        if (this._studentList != null && this._studentList.length > 0) {
            return of(this._studentList)
        }
        else {
            let url = `${this.baseService.appInfo.apiUrl}/${BANK_SERVICE_URL.ACTION_GET_BANK}`;
            return this.http.post<ResponseModel<StudentModel[]>>(url, input).pipe(
                map((data: ResponseModel<StudentModel[]>) => {
                    if (data != null && data.responseData != null) {
                        this._studentList = data.responseData;


                    }
                    return this._studentList;
                })
            );

        }
    }
    public makeInActiveStudent(input: RequestModel<StudentModel>): Observable<ResponseModel<ResultModel>> {

        let url = `${this.baseService.appInfo.apiUrl}/${BANK_SERVICE_URL.ACTION_MAKE_INACTIVE_BANK}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._studentList = [];
        }));

    }
    


}
