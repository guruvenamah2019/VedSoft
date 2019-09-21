import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { BankService, AuthenticationService } from 'src/app/core/services';
import { BankModel } from 'src/app/core/models/master-model';
import { CommonConstants } from 'src/app/core/enums';
import { ToastrService } from 'ngx-toastr';


@Component({
  templateUrl: 'add-bank.component.html',
})

export class AddBankComponent implements OnInit {
  @Input("model")
  model?: BankModel;
  @Output("onSave")
  onSave: EventEmitter<BankModel> = new EventEmitter<BankModel>();

  bankForm: FormGroup;
  loading = false;
  error = '';
  submitted: boolean = false;
  onNavigate() {
  }
  constructor(public bsModalRef: BsModalRef, private formBuilder: FormBuilder, private bankService: BankService, private userService: AuthenticationService) {
    console.log("AdminDashboardIndexComponent");

  }
  ngOnInit() {

    this.bankForm = this.formBuilder.group({
      name: new FormControl(this.model.bankName, [Validators.required, Validators.minLength(3)]),
      // parent: new FormControl(parent, []),
    });

  }
  get headerName(): string {
    let header: string = "";
    if (this.model.id > 0)
      header = "Edit Bank";
    else
      header = "Add Bank";

    return header;
  }

  get f() { return this.bankForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.bankForm.invalid) {
      return;
    }

    let input: BankModel = {
      bankName: this.f.name.value,
      userId: this.userService.loggedUser.id,
      id: this.model.id
    };

    if (this.model.id > 0) {
      this.editBank(input);
    }
    else {
      this.addBank(input);
    }

  }

  addBank(input: BankModel) {
    this.bankService.addBank(input).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.bankService.baseService.successMessage("Bank Added sucessfully");
          input.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(input);
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.bankService.baseService.errorMessage("Bank already exist");
        }
        else {
          this.bankService.baseService.errorMessage("Bank unable to add, please try later");
        }

      }

    });

  }

  editBank(input: BankModel) {
    this.bankService.updateBank(input).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.bankService.baseService.successMessage("Bank update sucessfully");
          input.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(input);
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.bankService.baseService.errorMessage("Bank already exist with this name");
        }
        else {
          this.bankService.baseService.errorMessage("Bank unable to update, please try later");
        }

      }

    });

  }

}