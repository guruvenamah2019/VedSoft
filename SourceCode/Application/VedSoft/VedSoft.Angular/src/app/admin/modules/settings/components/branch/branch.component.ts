
import { Component } from '@angular/core'
import { CustomerBranchModel } from 'src/app/core/models/master-model/customer-branch.model';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseService } from 'src/app/core/services';
import { BranchService } from 'src/app/core/services';
import { RequestModel } from 'src/app/core/models/shared-model';
import { CommonConstants } from 'src/app/core/enums';
import { AddBranchComponent } from './add-branch.component';

@Component({
    templateUrl: 'branch.component.html',
})


export class BranchSettingComponent  {
    branchList: CustomerBranchModel[] = [];
    bsModalRef: BsModalRef;
    constructor(private modalService: BsModalService, private baseService: BaseService, private router: Router,
        private activatedRoute: ActivatedRoute, private branchService: BranchService) {
        console.log("StandardsSettingsComponent");

    }
    ngOnInit() {

        this.activatedRoute.data.subscribe(x => {
            //this.level = x.level;
        })
        this.getBranchList();
    }

    getBranchList(){

        let branch: CustomerBranchModel = new CustomerBranchModel();
        let searchInput = this.baseService.getSearchRequestModel(branch);
        searchInput.pageNumber = 1;
        searchInput.pageSize = 100;

        this.branchService.getBranch(searchInput).subscribe(data=>{
            this.branchList = data;
        });

        
    }
    addBranch(): void {
        let inputModel: CustomerBranchModel = {
            id: 0,
            name: ""
        };
        this.branchOpen(inputModel);

    }

    
    editBranch(inputModel: CustomerBranchModel): void {

        this.branchOpen(inputModel);

    }
    deleteBranch(inputModel: CustomerBranchModel): void {

        let confir = confirm("Are you sure to delete");
        if (confir) {
            inputModel.userId =this.branchService.userSerice.loggedUser.id;

            let input: RequestModel<CustomerBranchModel> = this.baseService.getRequestModel(inputModel);

            this.branchService.makeInActiveBranch(input).subscribe(x => {
                if (x.responseData != null) {
                    if (x.responseData.statusId == CommonConstants.success) {
                        this.branchService.baseService.successMessage("Branch deleted sucessfully");
                        this.getBranchList();
                    }
                    else {
                        this.branchService.baseService.errorMessage("Branch unable to delete, please try later");
                    }
                }
            })

        }
    }

    branchOpen(inputModel: CustomerBranchModel) {
        const initialState = {
            model: inputModel
        };
        this.bsModalRef = this.modalService.show(AddBranchComponent, { ignoreBackdropClick: true, initialState,class:'modal-lg' });
        this.bsModalRef.content.onSave.subscribe((res: CustomerBranchModel) => {
            this.getBranchList();
        });
    }




}