import { Component } from '@angular/core'
import { CourseModel, SubjectHiearchyModel } from 'src/app/core/models/master-model';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseService, SubjectHiearchyService } from 'src/app/core/services';
import { CourseService } from 'src/app/core/services';
import { RequestModel } from 'src/app/core/models/shared-model';
import { CommonConstants } from 'src/app/core/enums';
import { AddBranchCourseComponent } from './add-course.component';


@Component({
    templateUrl: 'course.component.html',
})


export class BranchCourseComponent  {
    courseList: CourseModel[] = [];
    bsModalRef: BsModalRef;
    constructor(private modalService: BsModalService, private baseService: BaseService, private router: Router,
        private activatedRoute: ActivatedRoute, private courseService: CourseService, private subject:SubjectHiearchyService) {
        console.log("BranchCourseComponent");

    }
    ngOnInit() {

        this.activatedRoute.data.subscribe(x => {
            //this.level = x.level;
        })
        this.getCourseList();
    }

    getCourseList(){

        let course: CourseModel = new CourseModel();
        let searchInput = this.baseService.getSearchRequestModel(course);
        searchInput.pageNumber = 1;
        searchInput.pageSize = 100;

        this.courseService.getCourse(searchInput).subscribe(data=>{
            this.courseList = data;
        });

        
    }
    addCourse(): void {



        let inputModel: CourseModel = {
            id: 0,
            name: ""
        };
        this.courseOpen(inputModel);

    }

    
    editCourse(inputModel: CourseModel): void {

        this.courseOpen(inputModel);

    }
    deleteCourse(inputModel: CourseModel): void {

        let confir = confirm("Are you sure to delete");
        if (confir) {
            inputModel.userId =this.courseService.userSerice.loggedUser.id;

            let input: RequestModel<CourseModel> = this.baseService.getRequestModel(inputModel);

            this.courseService.makeInActiveCourse(input).subscribe(x => {
                if (x.responseData != null) {
                    if (x.responseData.statusId == CommonConstants.success) {
                        this.courseService.baseService.successMessage("Course deleted sucessfully");
                        this.getCourseList();
                    }
                    else {
                        this.courseService.baseService.errorMessage("Course unable to delete, please try later");
                    }
                }
            })

        }
    }

    courseOpen(inputModel: CourseModel) {

        let subject: SubjectHiearchyModel = new SubjectHiearchyModel();
        subject.hierarchyLevel = 1;
            let searchInput = this.subject.baseService.getSearchRequestModel(subject);
            searchInput.pageNumber = 1;
            searchInput.pageSize = 100;
    
        this.subject.getSubjectHierarchy(searchInput).subscribe(x=>{
       
      if(x.length>0){

        const initialState = {
            model: inputModel
        };
        this.bsModalRef = this.modalService.show(AddBranchCourseComponent, { ignoreBackdropClick: true, initialState,class:'modal-lg' });
        this.bsModalRef.content.onSave.subscribe((res: CourseModel) => {
            this.getCourseList();
        });
    }
    else{

        this.courseService.baseService.errorMessage("Please create subject first");

    }

    });
    }




}