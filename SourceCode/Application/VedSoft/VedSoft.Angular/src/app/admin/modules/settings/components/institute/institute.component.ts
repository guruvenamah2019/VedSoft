import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { InstituteModel } from 'src/app/core/models/master-model';
import { BaseService,  InstituteService } from 'src/app/core/services';
import { RequestModel } from 'src/app/core/models/shared-model';
import { CommonConstants } from 'src/app/core/enums';
import { AddInstituteComponent } from './add-institute.component';



@Component({
    templateUrl: 'institute.component.html',
})

export class InstituteSettingsComponent implements OnInit {

    level: number = 1;
    bsModalRef: BsModalRef;
    instituteList: InstituteModel[] = [];
    constructor(private modalService: BsModalService, private bankService: InstituteService, private baseService: BaseService) {
        console.log("InstituteSettingsComponent");

    }
    ngOnInit() {
        this.getInstituteList();
    }



    getInstituteList() {
        let bank: InstituteModel = new InstituteModel();
        let searchInput = this.baseService.getSearchRequestModel(bank);
        searchInput.pageNumber = 1;
        searchInput.pageSize = 100;

        this.bankService.getInstitute(searchInput).subscribe(x => {
            if (x != null) {
                this.instituteList = x;
            }
        })


    }

    addInstitute(): void {
        let inputModel: InstituteModel = {
            id: 0,
            name: ""
        };
        this.openPopup(inputModel);

    }


    editInstitute(inputModel: InstituteModel): void {

        this.openPopup(inputModel);

    }
    deleteInstitute(inputModel: InstituteModel): void {

        let confir = confirm("Are you sure to delete");
        if (confir) {

            let input: RequestModel<InstituteModel> = this.baseService.getRequestModel(inputModel);

            this.bankService.makeInActiveInstitute(input).subscribe(x => {
                if (x.responseData != null) {
                    if (x.responseData.statusId == CommonConstants.success) {
                        this.bankService.baseService.successMessage("Institute deleted sucessfully");
                        this.getInstituteList();
                    }
                    else {
                        this.bankService.baseService.errorMessage("Institute unable to delete, please try later");
                    }
                }
            })

        }
    }

    openPopup(inputModel: InstituteModel) {
        const initialState = {
            model: inputModel
        };
        this.bsModalRef = this.modalService.show(AddInstituteComponent, { ignoreBackdropClick: true, initialState });
        this.bsModalRef.content.onSave.subscribe((res: InstituteModel) => {
            this.getInstituteList();
        });
    }

}