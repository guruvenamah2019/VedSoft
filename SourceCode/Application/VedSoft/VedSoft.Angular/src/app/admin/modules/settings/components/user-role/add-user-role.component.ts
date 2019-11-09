import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { SubjectHiearchyModel } from 'src/app/core/models/master-model/subject-hiearchy.model';
import { CommonConstants } from 'src/app/core/enums';
import { UserRoleModel } from 'src/app/core/models/master-model';
import { UserRoleService } from 'src/app/core/services';


@Component({
  templateUrl: 'add-user-role.component.html',
})

export class AddUserRoleComponent implements OnInit {
  @Input('model')
  model?: UserRoleModel;
  @Output('onSave')
  onSave: EventEmitter<UserRoleModel> = new EventEmitter<UserRoleModel>();

  userRoleForm: FormGroup;
  loading = false;
  error = '';
  submitted: boolean = false;
  onNavigate() {
  }
  constructor(public bsModalRef: BsModalRef, private formBuilder: FormBuilder, private roleService: UserRoleService) {
    console.log('AddUserRoleComponent');

  }
  ngOnInit() {


    this.userRoleForm = this.formBuilder.group({
      name: new FormControl(this.model.name, [Validators.required, Validators.minLength(3)]),
    });
    /*
        if (this.model.id === 0 && this.model.hierarchyLevel > 1) {
          this.standardForm.controls.parent.setValidators([Validators.required]);
        }
        */

  }

  get headerName(): string {
    let header: string = '';
    if (this.model.id > 0)
      header = 'Edit Role';
    else
      header = 'Add Role';

    return header;
  }




  get f() { return this.userRoleForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.userRoleForm.invalid) {
      return;
    }

    const courseInput: UserRoleModel = {
      name: this.f.name.value,
      userId: this.roleService.userSerice.loggedUser.id,
      id: this.model.id
    };

    if (this.model.id > 0) {
      this.editStandard(courseInput);
    }    else {
      this.addStandard(courseInput);
    }

  }

  addStandard(courseInput: UserRoleModel) {
    this.roleService.addUserRole(courseInput).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId === CommonConstants.success) {
          this.roleService.baseService.successMessage('role Added sucessfully');
          courseInput.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(courseInput);
        }        else if (x.responseData.statusId === CommonConstants.duplicateRecord) {
          this.roleService.baseService.errorMessage('role already exist');
        }        else {
          this.roleService.baseService.errorMessage('role unable to add, please try later');
        }

      }

    });

  }

  editStandard(courseInput: UserRoleModel) {
    this.roleService.updateUserRole(courseInput).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId === CommonConstants.success) {
          this.roleService.baseService.successMessage('role update sucessfully');
          courseInput.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(courseInput);
        } else if (x.responseData.statusId === CommonConstants.duplicateRecord) {
          this.roleService.baseService.errorMessage('role already exist with this name');
        } else {
          this.roleService.baseService.errorMessage('role unable to update, please try later');
        }

      }

    });

  }

}