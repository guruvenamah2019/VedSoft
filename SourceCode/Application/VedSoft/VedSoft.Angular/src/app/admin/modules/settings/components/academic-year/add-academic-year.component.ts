import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { AcademicYearService, AuthenticationService } from 'src/app/core/services';
import { AcademicYearModel } from 'src/app/core/models/master-model';
import { CommonConstants } from 'src/app/core/enums';
import { ToastrService } from 'ngx-toastr';


@Component({
  templateUrl: 'add-academic-year.component.html',
})

export class AddAcademicYearComponent implements OnInit {
  @Input("model")
  model?: AcademicYearModel;
  @Output("onSave")
  onSave: EventEmitter<AcademicYearModel> = new EventEmitter<AcademicYearModel>();

  academicYearForm: FormGroup;
  loading = false;
  error = '';
  submitted: boolean = false;
  onNavigate() {
  }
  constructor(public bsModalRef: BsModalRef, private formBuilder: FormBuilder, private bankService: AcademicYearService, private userService: AuthenticationService) {
    console.log("AdminDashboardIndexComponent");

  }
  ngOnInit() {

    this.academicYearForm = this.formBuilder.group({
      name: new FormControl(this.model.academicYear, [Validators.required, Validators.minLength(3)]),
      // parent: new FormControl(parent, []),
    });

  }
  get headerName(): string {
    let header: string = "";
    if (this.model.id > 0)
      header = "Edit AcademicYear";
    else
      header = "Add AcademicYear";

    return header;
  }

  get f() { return this.academicYearForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.academicYearForm.invalid) {
      return;
    }

    let input: AcademicYearModel = {
      academicYear: this.f.name.value,
      userId: this.userService.loggedUser.id,
      id: this.model.id
    };

    if (this.model.id > 0) {
      this.editAcademicYear(input);
    }
    else {
      this.addAcademicYear(input);
    }

  }

  addAcademicYear(input: AcademicYearModel) {
    this.bankService.addAcademicYear(input).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.bankService.baseService.successMessage("AcademicYear Added sucessfully");
          input.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(input);
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.bankService.baseService.errorMessage("AcademicYear already exist");
        }
        else {
          this.bankService.baseService.errorMessage("AcademicYear unable to add, please try later");
        }

      }

    });

  }

  editAcademicYear(input: AcademicYearModel) {
    this.bankService.updateAcademicYear(input).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.bankService.baseService.successMessage("AcademicYear update sucessfully");
          input.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(input);
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.bankService.baseService.errorMessage("AcademicYear already exist with this name");
        }
        else {
          this.bankService.baseService.errorMessage("AcademicYear unable to update, please try later");
        }

      }

    });

  }

}