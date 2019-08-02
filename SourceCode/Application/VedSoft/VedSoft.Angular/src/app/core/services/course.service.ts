import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RequestModel, ResponseModel, ResultModel, SearchRequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { COURCE_SERVICE_URL } from "../constant/service-url";
import { CourseHiearchyModel } from '../models/master-model/course-hiearchy.model';
import { AuthenticationService } from '.';
import { map, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class CourseHiearchyService {

    private  courseHiearchy:  CourseHiearchyModel[]=[];

    constructor(private http: HttpClient, public baseService: BaseService,  public userSerice:AuthenticationService) {

    }

    public addCourseHierarchy(course: CourseHiearchyModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<CourseHiearchyModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${COURCE_SERVICE_URL.ACTION_ADD_COURSE_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x=>{
           this.courseHiearchy=[]; 
        }));

    }
    public updateCourseHierarchy(course: CourseHiearchyModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<CourseHiearchyModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${COURCE_SERVICE_URL.ACTION_UPDATE_COURSE_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x=>{
            this.courseHiearchy=[]; 
         }));

    }
    public getCourseHierarchy(input: SearchRequestModel<CourseHiearchyModel>): Observable<CourseHiearchyModel[]> {

        let level = input.requestParameter.hierarchyLevel;
if(this.courseHiearchy!=null && this.courseHiearchy.length>0){
    return of(this.courseHiearchy.filter(x=>x.hierarchyLevel == level))
}
else{
    input.requestParameter.hierarchyLevel=0;
        let url = `${this.baseService.appInfo.apiUrl}/${COURCE_SERVICE_URL.ACTION_GET_COURSE_HIERARCHY}`;
        return this.http.post<ResponseModel<CourseHiearchyModel[]>>(url, input).pipe(
            map((data:ResponseModel<CourseHiearchyModel[]>)=>{
                if(data!=null && data.responseData!=null)
                {
                    this.courseHiearchy = data.responseData;
                }
                return this.courseHiearchy.filter(x=>x.hierarchyLevel == level);
            })
        );

    }
}
    public makeInActiveCourseHierarchy(input: RequestModel<CourseHiearchyModel>): Observable<ResponseModel<ResultModel>> {

        let url = `${this.baseService.appInfo.apiUrl}/${COURCE_SERVICE_URL.ACTION_MAKE_INACTIVE_COURSE_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x=>{
            this.courseHiearchy=[]; 
         }));

    }
    getLevelName(levelId:number):string{
        let levelName= "";
        switch(levelId){
            case 0:
                    levelName ="";
                    break;
            case 1:
                    levelName ="Standards";
                    break;
                    case 2:
                    levelName ="Streams";
                    break;
                    case 3:
                    levelName ="Subjects";
                    break;
                    case 4:
                    levelName ="Topics";
                    break;

        }
        return levelName;
    }


}
