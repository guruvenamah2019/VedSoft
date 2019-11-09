import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RequestModel, ResponseModel, ResultModel, SearchRequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { SUBJECT_SERVICE_URL } from "../constant/service-url";
import { SubjectHiearchyModel } from '../models/master-model/subject-hiearchy.model';
import { AuthenticationService } from './authentication.service';
import { map, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class SubjectHiearchyService {

    private subjectHiearchy: SubjectHiearchyModel[] = [];

    public get SubjectHiearchy(){
        return this.subjectHiearchy;
    }

    constructor(private http: HttpClient, public baseService: BaseService, public userSerice: AuthenticationService) {

    }

    public addSubjectHierarchy(course: SubjectHiearchyModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<SubjectHiearchyModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${SUBJECT_SERVICE_URL.ACTION_ADD_SUBJECT_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.subjectHiearchy = [];
        }));

    }
    public updateSubjectHierarchy(course: SubjectHiearchyModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<SubjectHiearchyModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${SUBJECT_SERVICE_URL.ACTION_UPDATE_SUBJECT_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.subjectHiearchy = [];
        }));

    }
    public getSubjectHierarchy(input: SearchRequestModel<SubjectHiearchyModel>): Observable<SubjectHiearchyModel[]> {
/*
        this.courseHiearchy.push({
            hierarchyLevel:1,
            id:1,
            name:"12th",
           parentId:0,
        });
        this.courseHiearchy.push({
            hierarchyLevel:2,
            id:2,
            name:"Maths",
           parentId:1,
        });
        this.courseHiearchy.push({
            hierarchyLevel:3,
            id:3,
            name:"Mathematics",
           parentId:2,
        });
        this.courseHiearchy.push({
            hierarchyLevel:4,
            id:4,
            name:"Algebra",
           parentId:3,
        });*/
        this.subjectHiearchy.forEach(x=>{
            x.parent =  this.subjectHiearchy.find(p=>p.id ==x.parentId)
        });

        let level = input.requestParameter.hierarchyLevel;
        if (this.subjectHiearchy != null && this.subjectHiearchy.length > 0) {
            return of(this.subjectHiearchy.filter(x => x.hierarchyLevel == level))
        }
        else {
            input.requestParameter.hierarchyLevel = 0;
            let url = `${this.baseService.appInfo.apiUrl}/${SUBJECT_SERVICE_URL.ACTION_GET_SUBJECT_HIERARCHY}`;
            return this.http.post<ResponseModel<SubjectHiearchyModel[]>>(url, input).pipe(
                map((data: ResponseModel<SubjectHiearchyModel[]>) => {
                    if (data != null && data.responseData != null) {
                        this.subjectHiearchy = data.responseData;

                        this.subjectHiearchy.forEach(x=>{
                            x.parent = data.responseData.find(p=>p.id ==x.parentId)
                        });


                    }
                    return this.subjectHiearchy.filter(x => x.hierarchyLevel == level);
                })
            );

        }
    }
    public makeInActiveSubjectHierarchy(input: RequestModel<SubjectHiearchyModel>): Observable<ResponseModel<ResultModel>> {

        let url = `${this.baseService.appInfo.apiUrl}/${SUBJECT_SERVICE_URL.ACTION_MAKE_INACTIVE_SUBJECT_HIERARCHY}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.subjectHiearchy = [];
        }));

    }
    getLevelName(levelId: number): string {
        let levelName = "";
        switch (levelId) {
            case 0:
                levelName = "";
                break;
            case 1:
                levelName = "Standard";
                break;
            case 2:
                levelName = "Stream";
                break;
            case 3:
                levelName = "Subject";
                break;
            case 4:
                levelName = "Topic";
                break;

        }
        return levelName;
    }

    getLevelsName(levelId: number): string {
        let levelName = "";
        switch (levelId) {
            case 0:
                levelName = "";
                break;
            case 1:
                levelName = "Standards";
                break;
            case 2:
                levelName = "Streams";
                break;
            case 3:
                levelName = "Subjects";
                break;
            case 4:
                levelName = "Topics";
                break;

        }
        return levelName;
    }


}
