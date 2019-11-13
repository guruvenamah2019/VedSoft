import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { BankService, AuthenticationService } from 'src/app/core/services';
import { UserMasterModel } from 'src/app/core/models/user-model';
import { AddressModel } from 'src/app/core/models/master-model';


@Component({
  templateUrl: 'profile.component.html',
  selector: 'ved-std-profile'

})

export class StudentProfileComponent implements OnInit {

  loading = false;
  error = '';
  submitted: boolean = false;
  studentForm: FormGroup;
  model: UserMasterModel = new UserMasterModel();
  onNavigate() {
  }
  constructor(private userService: AuthenticationService, private formBuilder: FormBuilder, ) {
    console.log("StudentProfileComponent");

  }
  ngOnInit() {
    this.model = {
      firstName: '',
      lastName: '',
      notificationEmailId: '',
      addressInfo: ''

    };
    this.studentForm = this.formBuilder.group({
      name: new FormControl(this.model.firstName, [Validators.required, Validators.minLength(3)]),
      code: new FormControl(this.model.lastName, [Validators.required, Validators.minLength(3)]),
      contactNumber: new FormControl(this.model.notificationEmailId, [Validators.required, Validators.minLength(10)]),
      //parent: new FormControl(parent, []),
    });

  }

  private addFormControl(name: string, formGroup: FormGroup): void {
    this.studentForm.addControl(name, formGroup);
  }

  get f() { return this.studentForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.studentForm.invalid) {
      return;
    }

    let address: AddressModel = this.f.branchAddress.value;

    let contact = [];
    contact.push(this.f.contactNumber.value);


  }



}