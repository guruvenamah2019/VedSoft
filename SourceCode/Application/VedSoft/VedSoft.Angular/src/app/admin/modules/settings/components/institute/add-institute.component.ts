import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { InstituteService, AuthenticationService } from 'src/app/core/services';
import { InstituteModel } from 'src/app/core/models/master-model';
import { CommonConstants } from 'src/app/core/enums';
import { ToastrService } from 'ngx-toastr';


@Component({
  templateUrl: 'add-institute.component.html',
})

export class AddInstituteComponent implements OnInit {
  @Input("model")
  model?: InstituteModel;
  @Output("onSave")
  onSave: EventEmitter<InstituteModel> = new EventEmitter<InstituteModel>();

  instituteForm: FormGroup;
  loading = false;
  error = '';
  submitted: boolean = false;
  onNavigate() {
  }
  constructor(public bsModalRef: BsModalRef, private formBuilder: FormBuilder, private instituteService: InstituteService, private userService: AuthenticationService) {
    console.log("AddInstituteComponent");

  }
  ngOnInit() {

    this.instituteForm = this.formBuilder.group({
      name: new FormControl(this.model.name, [Validators.required, Validators.minLength(3)]),
      // parent: new FormControl(parent, []),
    });

  }
  get headerName(): string {
    let header: string = "";
    if (this.model.id > 0)
      header = "Edit Institute";
    else
      header = "Add Institute";

    return header;
  }

  get f() { return this.instituteForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.instituteForm.invalid) {
      return;
    }

    let input: InstituteModel = {
      name: this.f.name.value,
      userId: this.userService.loggedUser.id,
      id: this.model.id
    };

    if (this.model.id > 0) {
      this.editInstitute(input);
    }
    else {
      this.addInstitute(input);
    }

  }

  addInstitute(input: InstituteModel) {
    this.instituteService.addInstitute(input).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.instituteService.baseService.successMessage("Institute Added sucessfully");
          input.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(input);
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.instituteService.baseService.errorMessage("Institute already exist");
        }
        else {
          this.instituteService.baseService.errorMessage("Institute unable to add, please try later");
        }

      }

    });

  }

  editInstitute(input: InstituteModel) {
    this.instituteService.updateInstitute(input).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.instituteService.baseService.successMessage("Institute update sucessfully");
          input.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(input);
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.instituteService.baseService.errorMessage("Institute already exist with this name");
        }
        else {
          this.instituteService.baseService.errorMessage("Institute unable to update, please try later");
        }

      }

    });

  }

}