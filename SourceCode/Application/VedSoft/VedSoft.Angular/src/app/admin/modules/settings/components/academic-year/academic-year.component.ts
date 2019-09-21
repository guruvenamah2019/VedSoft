import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AcademicYearModel } from 'src/app/core/models/master-model';
import { BaseService, AcademicYearService } from 'src/app/core/services';
import { RequestModel } from 'src/app/core/models/shared-model';
import { CommonConstants } from 'src/app/core/enums';
import { AddAcademicYearComponent } from './add-academic-year.component';



@Component({
    templateUrl: 'academic-year.component.html',
})

export class AcademicYearSettingsComponent implements OnInit {

    level: number = 1;
    bsModalRef: BsModalRef;
    academicYearList: AcademicYearModel[] = [];
    constructor(private modalService: BsModalService, private academicYearService: AcademicYearService, private baseService: BaseService) {
        console.log("AcademicYearSettingsComponent");

    }
    ngOnInit() {
        this.getAcademicYearList();
    }



    getAcademicYearList() {
        let bank: AcademicYearModel = new AcademicYearModel();
        let searchInput = this.baseService.getSearchRequestModel(bank);
        searchInput.pageNumber = 1;
        searchInput.pageSize = 100;

        this.academicYearService.getAcademicYear(searchInput).subscribe(x => {
            if (x != null) {
                this.academicYearList = x;
            }
        })


    }

    addAcademicYear(): void {
        let inputModel: AcademicYearModel = {
            id: 0,
            academicYear: ""
        };
        this.openPopup(inputModel);

    }


    editAcademicYear(inputModel: AcademicYearModel): void {

        this.openPopup(inputModel);

    }
    deleteAcademicYear(inputModel: AcademicYearModel): void {

        let confir = confirm("Are you sure to delete");
        if (confir) {

            let input: RequestModel<AcademicYearModel> = this.baseService.getRequestModel(inputModel);

            this.academicYearService.makeInActiveAcademicYear(input).subscribe(x => {
                if (x.responseData != null) {
                    if (x.responseData.statusId == CommonConstants.success) {
                        this.academicYearService.baseService.successMessage("AcademicYear deleted sucessfully");
                        this.getAcademicYearList();
                    }
                    else {
                        this.academicYearService.baseService.errorMessage("AcademicYear unable to delete, please try later");
                    }
                }
            })

        }
    }

    openPopup(inputModel: AcademicYearModel) {
        const initialState = {
            model: inputModel
        };
        this.bsModalRef = this.modalService.show(AddAcademicYearComponent, { ignoreBackdropClick: true, initialState });
        this.bsModalRef.content.onSave.subscribe((res: AcademicYearModel) => {
            this.getAcademicYearList();
        });
    }

}