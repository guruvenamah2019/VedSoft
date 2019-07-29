import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RequestModel, ResponseModel, ResultModel, SearchRequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { COURCE_SERVICE_URL } from "../constant/service-url";
import { CourseHiearchyModel } from '../models/master-model/course-hiearchy.model';

@Injectable({
    providedIn: 'root'
})
export class CourseHiearchyService {


    constructor(private http: HttpClient, private baseService: BaseService) {

    }

    public addCourseHierarchy(course: CourseHiearchyModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<CourseHiearchyModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${COURCE_SERVICE_URL.ACTION_ADD_COURSE_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input);

    }
    public updateCourseHierarchy(course: CourseHiearchyModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<CourseHiearchyModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${COURCE_SERVICE_URL.ACTION_UPDATE_COURSE_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input);

    }
    public getCourseHierarchy(input: SearchRequestModel<CourseHiearchyModel>): Observable<ResponseModel<CourseHiearchyModel[]>> {


        let url = `${this.baseService.appInfo.apiUrl}/${COURCE_SERVICE_URL.ACTION_GET_COURSE_HIERARCHY}`;
        return this.http.post<ResponseModel<CourseHiearchyModel[]>>(url, input);

    }
    public makeInActiveCourseHierarchy(input: RequestModel<CourseHiearchyModel>): Observable<ResponseModel<ResultModel>> {

        let url = `${this.baseService.appInfo.apiUrl}/${COURCE_SERVICE_URL.ACTION_MAKE_INACTIVE_COURSE_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input);

    }


}
