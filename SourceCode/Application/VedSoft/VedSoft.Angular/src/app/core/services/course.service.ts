import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RequestModel, ResponseModel, ResultModel, SearchRequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { COURSE_SERVICE_URL } from '../constant/service-url';
import { CourseModel } from '../models/master-model';
import { AuthenticationService } from './authentication.service';
import { map, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class CourseService {

    private courseList: CourseModel[] = [];

    public get Course() {
        return this.courseList;
    }
    constructor(private http: HttpClient, public baseService: BaseService, public userSerice: AuthenticationService) {

    }

    public addCourse(course: CourseModel): Observable<ResponseModel<ResultModel>> {

        const input: RequestModel<CourseModel> = this.baseService.getRequestModel(course);

        const url = `${this.baseService.appInfo.apiUrl}/${COURSE_SERVICE_URL.ACTION_ADD_COURSE_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.courseList = [];
        }));

    }
    public updateCourse(course: CourseModel): Observable<ResponseModel<ResultModel>> {

        const input: RequestModel<CourseModel> = this.baseService.getRequestModel(course);

        const url = `${this.baseService.appInfo.apiUrl}/${COURSE_SERVICE_URL.ACTION_UPDATE_COURSE_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.courseList = [];
        }));

    }
    public getCourse(input: SearchRequestModel<CourseModel>): Observable<CourseModel[]> {
        if (this.courseList != null && this.courseList.length > 0) {
            return of(this.courseList);
        } else {
            const url = `${this.baseService.appInfo.apiUrl}/${COURSE_SERVICE_URL.ACTION_GET_COURSE_HIERARCHY}`;
            return this.http.post<ResponseModel<CourseModel[]>>(url, input).pipe(
                map((data: ResponseModel<CourseModel[]>) => {
                    if (data != null && data.responseData != null) {
                        this.courseList = data.responseData;
                    }
                    return this.courseList;
                })
            );

        }
    }
    public makeInActiveCourse(input: RequestModel<CourseModel>): Observable<ResponseModel<ResultModel>> {

        const url = `${this.baseService.appInfo.apiUrl}/${COURSE_SERVICE_URL.ACTION_MAKE_INACTIVE_COURSE_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.courseList = [];
        }));

    }
}
