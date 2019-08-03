import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AddStandardComponent } from '../add-standard/add-standard.component';
import { CourseHiearchyModel } from 'src/app/core/models/master-model/course-hiearchy.model';
import { CourseHiearchyService, BaseService } from 'src/app/core/services';
import { RequestModel } from 'src/app/core/models/shared-model';
import { CommonConstants } from 'src/app/core/enums';



@Component({
    templateUrl: 'standards.component.html',
})

export class StandardsSettingsComponent implements OnInit {

    level: number = 1;
    bsModalRef: BsModalRef;
    courseList: CourseHiearchyModel[] = [];
    constructor(private modalService: BsModalService, private courseService: CourseHiearchyService, private baseService: BaseService, private router: Router,
        private activatedRoute: ActivatedRoute) {
        console.log("StandardsSettingsComponent");

    }
    ngOnInit() {

        this.activatedRoute.data.subscribe(x => {
            this.level = x.level;
        })
        this.getCourseList();
    }

    get parentLevel(): number {
        return this.level - 1;
    }
    get levelName(): string {

        let levelName = this.courseService.getLevelsName(this.level);


        return levelName;
    }

    get parentLevelName(): string {
        let levelName = this.courseService.getLevelsName(this.parentLevel);

        return levelName;


    }




    getCourseList() {
        let course: CourseHiearchyModel = new CourseHiearchyModel();
        course.hierarchyLevel = this.level;
        let searchInput = this.baseService.getSearchRequestModel(course);
        searchInput.pageNumber = 1;
        searchInput.pageSize = 100;

        this.courseService.getCourseHierarchy(searchInput).subscribe(x => {
            if (x != null) {
                this.courseList = x;
            }
        })


    }

    addStandard(): void {
        let inputModel: CourseHiearchyModel = {
            hierarchyLevel: this.level,
            parentId: 0,
            id: 0,
            name: ""
        };
        this.standardOpen(inputModel);

    }

    getParentName(item: CourseHiearchyModel) {
        let name = "";
        if (item) {
            name = item.name;
            if (item.parent) {
                return name+ "->" + this.getParentName(item.parent)
            }
        }

        return name;
    }

    editStandard(inputModel: CourseHiearchyModel): void {

        this.standardOpen(inputModel);

    }
    deleteStandard(inputModel: CourseHiearchyModel): void {

        let confir = confirm("Are you sure to delete");
        if (confir) {

            let input: RequestModel<CourseHiearchyModel> = this.baseService.getRequestModel(inputModel);

            this.courseService.makeInActiveCourseHierarchy(input).subscribe(x => {
                if (x.responseData != null) {
                    if (x.responseData.statusId == CommonConstants.success) {
                        this.courseService.baseService.successMessage("Standard deleted sucessfully");
                        this.getCourseList();
                    }
                    else {
                        this.courseService.baseService.errorMessage("Standard unable to delete, please try later");
                    }
                }
            })

        }
    }

    standardOpen(inputModel: CourseHiearchyModel) {
        const initialState = {
            model: inputModel
        };
        this.bsModalRef = this.modalService.show(AddStandardComponent, { ignoreBackdropClick: true, initialState });
        this.bsModalRef.content.onSave.subscribe((res: CourseHiearchyModel) => {
            this.getCourseList();
        });
    }

}