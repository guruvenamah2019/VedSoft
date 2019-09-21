import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { BankModel } from 'src/app/core/models/master-model';
import { BaseService, BankService, AuthenticationService } from 'src/app/core/services';
import { RequestModel } from 'src/app/core/models/shared-model';
import { CommonConstants } from 'src/app/core/enums';
import { AddBankComponent } from './add-bank.component';



@Component({
    templateUrl: 'bank.component.html',
})

export class BankSettingsComponent implements OnInit {

    level: number = 1;
    bsModalRef: BsModalRef;
    bankList: BankModel[] = [];
    constructor(private modalService: BsModalService, private bankService: BankService, private baseService: BaseService,private userService: AuthenticationService) {
        console.log("BankSettingsComponent");

    }
    ngOnInit() {
        this.getBankList();
    }



    getBankList() {
        let bank: BankModel = new BankModel();
        let searchInput = this.baseService.getSearchRequestModel(bank);
        searchInput.pageNumber = 1;
        searchInput.pageSize = 100;

        this.bankService.getBank(searchInput).subscribe(x => {
            if (x != null) {
                this.bankList = x;
            }
        })


    }

    addBank(): void {
        let inputModel: BankModel = {
            id: 0,
            bankName: ""
        };
        this.openPopup(inputModel);

    }


    editBank(inputModel: BankModel): void {

        this.openPopup(inputModel);

    }
    deleteBank(inputModel: BankModel): void {

        let confir = confirm("Are you sure to delete");
        if (confir) {
            inputModel.userId =this.userService.loggedUser.id;

            let input: RequestModel<BankModel> = this.baseService.getRequestModel(inputModel);

            this.bankService.makeInActiveBank(input).subscribe(x => {
                if (x.responseData != null) {
                    if (x.responseData.statusId == CommonConstants.success) {
                        this.bankService.baseService.successMessage("Bank deleted sucessfully");
                        this.getBankList();
                    }
                    else {
                        this.bankService.baseService.errorMessage("Bank unable to delete, please try later");
                    }
                }
            })

        }
    }

    openPopup(inputModel: BankModel) {
        const initialState = {
            model: inputModel
        };
        this.bsModalRef = this.modalService.show(AddBankComponent, { ignoreBackdropClick: true, initialState });
        this.bsModalRef.content.onSave.subscribe((res: BankModel) => {
            this.getBankList();
        });
    }

}