import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AddStandardComponent } from './add-subject.component';
import { SubjectHiearchyModel } from 'src/app/core/models/master-model/subject-hiearchy.model';
import { SubjectHiearchyService, BaseService } from 'src/app/core/services';
import { RequestModel } from 'src/app/core/models/shared-model';
import { CommonConstants } from 'src/app/core/enums';



@Component({
    templateUrl: 'subject.component.html',
})

export class SubjectSettingsComponent implements OnInit {

    level: number = 1;
    bsModalRef: BsModalRef;
    courseList: SubjectHiearchyModel[] = [];
    constructor(private modalService: BsModalService, private subjectService: SubjectHiearchyService, private baseService: BaseService, private router: Router,
        private activatedRoute: ActivatedRoute) {
        console.log("StandardsSettingsComponent");

    }
    ngOnInit() {

        this.activatedRoute.data.subscribe(x => {
            this.level = x.level;
        })
        this.getSubjectList();
    }

    get parentLevel(): number {
        return this.level - 1;
    }
    get levelName(): string {

        let levelName = this.subjectService.getLevelsName(this.level);


        return levelName;
    }

    get parentLevelName(): string {
        let levelName = this.subjectService.getLevelsName(this.parentLevel);

        return levelName;


    }




    getSubjectList() {
        let course: SubjectHiearchyModel = new SubjectHiearchyModel();
        course.hierarchyLevel = this.level;
        let searchInput = this.baseService.getSearchRequestModel(course);
        searchInput.pageNumber = 1;
        searchInput.pageSize = 100;

        this.subjectService.getSubjectHierarchy(searchInput).subscribe(x => {
            if (x != null) {
                this.courseList = x;
            }
        })


    }

    addStandard(): void {
        let inputModel: SubjectHiearchyModel = {
            hierarchyLevel: this.level,
            parentId: 0,
            id: 0,
            name: ""
        };
        this.standardOpen(inputModel);

    }

    getParentName(item: SubjectHiearchyModel) {
        let name = "";
        if (item) {
            name = item.name;
            if (item.parent) {
                return name+ "->" + this.getParentName(item.parent)
            }
        }

        return name;
    }

    editStandard(inputModel: SubjectHiearchyModel): void {

        this.standardOpen(inputModel);

    }
    deleteStandard(inputModel: SubjectHiearchyModel): void {

        let confir = confirm("Are you sure to delete");
        if (confir) {
            inputModel.userId = this.subjectService.userSerice.loggedUser.id;

            let input: RequestModel<SubjectHiearchyModel> = this.baseService.getRequestModel(inputModel);

            this.subjectService.makeInActiveSubjectHierarchy(input).subscribe(x => {
                if (x.responseData != null) {
                    if (x.responseData.statusId == CommonConstants.success) {
                        this.subjectService.baseService.successMessage("Standard deleted sucessfully");
                        this.getSubjectList();
                    }
                    else {
                        this.subjectService.baseService.errorMessage("Standard unable to delete, please try later");
                    }
                }
            })

        }
    }

    standardOpen(inputModel: SubjectHiearchyModel) {
        const initialState = {
            model: inputModel
        };
        this.bsModalRef = this.modalService.show(AddStandardComponent, { ignoreBackdropClick: true, initialState });
        this.bsModalRef.content.onSave.subscribe((res: SubjectHiearchyModel) => {
            this.getSubjectList();
        });
    }

}