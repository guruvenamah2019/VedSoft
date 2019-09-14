import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CourseHiearchyModel } from 'src/app/core/models/master-model/course-hiearchy.model';
import { CommonConstants } from 'src/app/core/enums';
import { CustomerBranchModel } from 'src/app/core/models/master-model/customer-branch.model';
import { BranchService } from 'src/app/core/services';


@Component({
  templateUrl: 'add-branch.component.html',
})

export class AddBranchComponent implements OnInit {
  @Input("model")
  model?: CustomerBranchModel;
  @Output("onSave")
  onSave: EventEmitter<CustomerBranchModel> = new EventEmitter<CustomerBranchModel>();

  branchForm: FormGroup;
  loading = false;
  error = '';
  submitted: boolean = false;
  onNavigate() {
  }
  constructor(private bsModalRef: BsModalRef, private formBuilder: FormBuilder, private branchService: BranchService) {
    console.log("AddBranchComponent");

  }
  ngOnInit() {


    this.branchForm = this.formBuilder.group({
      name: new FormControl(this.model.name, [Validators.required, Validators.minLength(3)]),
      code: new FormControl(this.model.code, [Validators.required, Validators.minLength(3)]),
      //parent: new FormControl(parent, []),
    });
/*
    if (this.model.id == 0 && this.model.hierarchyLevel > 1) {
      this.standardForm.controls.parent.setValidators([Validators.required]);
    }

*/

  }

  get headerName():string{
    let header:string="";
    if(this.model.id>0)
    header="Edit Branch";
    else
    header="Add Branch";

    return header;
  }


 

  get f() { return this.branchForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.branchForm.invalid) {
      return;
    }

    let courseInput: CustomerBranchModel = {
      name: this.f.name.value,
      code: this.f.code.value,
      userId: this.branchService.userSerice.loggedUser.id,
      id: this.model.id
    };

    if (this.model.id > 0) {
      this.editStandard(courseInput);
    }
    else {
      this.addStandard(courseInput);
    }

  }

  addStandard(courseInput: CourseHiearchyModel) {
    this.branchService.addBranch(courseInput).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.branchService.baseService.successMessage("branch Added sucessfully");
          courseInput.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(courseInput);
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.branchService.baseService.errorMessage("branch already exist");
        }
        else {
          this.branchService.baseService.errorMessage("branch unable to add, please try later");
        }

      }

    });

  }

  editStandard(courseInput: CourseHiearchyModel) {
    this.branchService.updateBranch(courseInput).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.branchService.baseService.successMessage("branch update sucessfully");
          courseInput.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(courseInput);
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.branchService.baseService.errorMessage("branch already exist with this name");
        }
        else {
          this.branchService.baseService.errorMessage("branch unable to update, please try later");
        }

      }

    });

  }

}