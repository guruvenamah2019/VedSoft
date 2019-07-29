import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AddStandardComponent } from '../add-standard/add-standard.component';
import { CourseHiearchyModel } from 'src/app/core/models/master-model/course-hiearchy.model';
import { CourseHiearchyService, BaseService } from 'src/app/core/services';
import { servicesVersion } from 'typescript';



@Component({
    templateUrl: 'standards.component.html',
})

export class StandardsSettingsComponent implements OnInit {
   
    bsModalRef: BsModalRef;
    courseList:CourseHiearchyModel[]=[];
    constructor(private modalService: BsModalService, private courseService:CourseHiearchyService, private baseService:BaseService) {
        console.log("AdminDashboardIndexComponent");
        
    }
    ngOnInit() {
        this.getCourseList();
    }

    getCourseList(){
        let course:CourseHiearchyModel = new CourseHiearchyModel();
        course.hierarchyLevel =0;

       let searchInput = this.baseService.getSearchRequestModel(course);
       searchInput.pageNumber=1;
       searchInput.pageSize=100;

       this.courseService.getCourseHierarchy(searchInput).subscribe(x=>{
           if(x.responseData!=null){
               this.courseList = x.responseData;
           }
       })
        

    }

    addStandard():void{
        const initialState = {
           // model: model
        };
        this.bsModalRef = this.modalService.show(AddStandardComponent, { ignoreBackdropClick: true, initialState });

    }
    
}