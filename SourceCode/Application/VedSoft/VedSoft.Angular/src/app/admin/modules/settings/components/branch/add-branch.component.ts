import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CustomerBranchModel, AddressModel } from 'src/app/core/models/master-model';
import { CommonConstants } from 'src/app/core/enums';
import { BranchService } from 'src/app/core/services';
import { JsonPipe } from '@angular/common';


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
  //address:AddressModel= new AddressModel();
  onNavigate() {
  }
  constructor(public bsModalRef: BsModalRef, private formBuilder: FormBuilder, private branchService: BranchService) {
    console.log("AddBranchComponent");

  }
  ngOnInit() {
    
    
    this.branchForm = this.formBuilder.group({
      name: new FormControl(this.model.name, [Validators.required, Validators.minLength(3)]),
      code: new FormControl(this.model.code, [Validators.required, Validators.minLength(3)]),
      contactNumber: new FormControl(this.model.primaryContactNumber, [Validators.required, Validators.minLength(10)]),
      //parent: new FormControl(parent, []),
    });
/*
    if (this.model.id == 0 && this.model.hierarchyLevel > 1) {
      this.standardForm.controls.parent.setValidators([Validators.required]);
    }

*/

  }

  private addFormControl(name: string, formGroup: FormGroup) : void {
		this.branchForm.addControl(name, formGroup);
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

    let address:AddressModel = this.f.branchAddress.value;

    let contact = [];
    contact.push( this.f.contactNumber.value);

    let courseInput: CustomerBranchModel = {
      name: this.f.name.value,
      code: this.f.code.value,
      userId: this.branchService.userSerice.loggedUser.id,
      id: this.model.id,
      address: JSON.stringify(address),
      contactNumber: JSON.stringify(contact)
    };

    if (this.model.id > 0) {
      this.editStandard(courseInput);
    }
    else {
      this.addStandard(courseInput);
    }

  }

  addStandard(courseInput: CustomerBranchModel) {
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

  editStandard(courseInput: CustomerBranchModel) {
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