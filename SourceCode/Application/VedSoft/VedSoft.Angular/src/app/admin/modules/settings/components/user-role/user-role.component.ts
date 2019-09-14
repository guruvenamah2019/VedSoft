
import { Component } from '@angular/core'
import { UserRoleModel } from 'src/app/core/models/master-model';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseService } from 'src/app/core/services';
import { BranchService } from 'src/app/core/services';
import { RequestModel } from 'src/app/core/models/shared-model';
import { CommonConstants } from 'src/app/core/enums';
import { AddUserRoleComponent } from './add-user-role.component';
import { UserRoleService } from 'src/app/core/services/user-role.service';

@Component({
    templateUrl: 'user-role.component.html',
})


export class UserRoleSettingComponent  {
    roleList: UserRoleModel[] = [];
    bsModalRef: BsModalRef;
    constructor(private modalService: BsModalService, private baseService: BaseService, private router: Router,
        private activatedRoute: ActivatedRoute, private roleService: UserRoleService) {
        console.log("UserRoleSettingComponent");

    }
    ngOnInit() {

        this.activatedRoute.data.subscribe(x => {
            //this.level = x.level;
        })
        this.getUserRoleList();
    }

    getUserRoleList(){

        let branch: UserRoleModel = new UserRoleModel();
        let searchInput = this.baseService.getSearchRequestModel(branch);
        searchInput.pageNumber = 1;
        searchInput.pageSize = 100;

        this.roleService.getUserRole(searchInput).subscribe(data=>{
            this.roleList = data;
        });

        
    }
    addRole(): void {
        let inputModel: UserRoleModel = {
            id: 0,
            name: ""
        };
        this.openUserRole(inputModel);

    }

    editRole(inputModel: UserRoleModel): void {

        this.openUserRole(inputModel);

    }
    deleteRole(inputModel: UserRoleModel): void {

        let confir = confirm("Are you sure to delete");
        if (confir) {

            let input: RequestModel<UserRoleModel> = this.baseService.getRequestModel(inputModel);

            this.roleService.makeInActiveUserRole(input).subscribe(x => {
                if (x.responseData != null) {
                    if (x.responseData.statusId == CommonConstants.success) {
                        this.roleService.baseService.successMessage("Branch deleted sucessfully");
                        this.getUserRoleList();
                    }
                    else {
                        this.roleService.baseService.errorMessage("Branch unable to delete, please try later");
                    }
                }
            })

        }
    }

    openUserRole(inputModel: UserRoleModel) {
        const initialState = {
            model: inputModel
        };
        this.bsModalRef = this.modalService.show(AddUserRoleComponent, { ignoreBackdropClick: true, initialState });
        this.bsModalRef.content.onSave.subscribe((res: UserRoleModel) => {
            this.getUserRoleList();
        });
    }




}