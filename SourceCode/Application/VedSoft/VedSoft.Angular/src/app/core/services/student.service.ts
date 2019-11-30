import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RequestModel, ResponseModel, ResultModel, SearchRequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { STUDENT_SERVICE_URL } from "../constant/service-url";
import { map, tap } from 'rxjs/operators';
import { StudentBaseModel, StudentAdmissionModel } from '../models/student-model/student-master.model';

@Injectable({
    providedIn: 'root'
})
export class StudentService {

    private _studentList: StudentBaseModel[] = [];

    public get StudentList() {
        return this._studentList;
    }

    constructor(private http: HttpClient, public baseService: BaseService) {

        


    }

    public addStudent(course: StudentAdmissionModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<StudentAdmissionModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${STUDENT_SERVICE_URL.ACTION_ADD_STUDENT}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._studentList = [];
        }));

    }
    public updateStudent(course: StudentAdmissionModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<StudentAdmissionModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${STUDENT_SERVICE_URL.ACTION_UPDATE_STUDENT}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._studentList = [];
        }));

    }
    public getStudent(input: SearchRequestModel<StudentBaseModel>): Observable<StudentBaseModel[]> {

        let url = `${this.baseService.appInfo.apiUrl}/${STUDENT_SERVICE_URL.ACTION_GET_STUDENT}`;
        return this.http.post<ResponseModel<StudentBaseModel[]>>(url, input).pipe(
            map((data: ResponseModel<StudentBaseModel[]>) => {
                if (data != null && data.responseData != null) {
                    this._studentList = data.responseData;


                }
                return this._studentList;
            })
        );

    }
    public makeInActiveStudent(input: RequestModel<StudentBaseModel>): Observable<ResponseModel<ResultModel>> {

        let url = `${this.baseService.appInfo.apiUrl}/${STUDENT_SERVICE_URL.ACTION_MAKE_INACTIVE_STUDENT}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this._studentList = [];
        }));

    }



}
