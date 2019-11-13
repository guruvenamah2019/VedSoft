import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { BankService, AuthenticationService } from 'src/app/core/services';
import { AddressModel } from 'src/app/core/models/master-model';
import { StudentModel } from 'src/app/core/models/student-model';


@Component({
  templateUrl: 'profile.component.html',
  selector: 'ved-std-profile'

})

export class StudentProfileComponent implements OnInit {

  loading = false;
  error = '';
  submitted: boolean = false;
  studentForm: FormGroup;
  model: StudentModel = new StudentModel();
  onNavigate() {
  }
  constructor(private userService: AuthenticationService, private formBuilder: FormBuilder, ) {
    console.log("StudentProfileComponent");

  }
  ngOnInit() {
    this.model = {
      User: {
        firstName:'',
        lastName:'',
        addressInfo:'',
        notificationEmailId:'',
        
      },
    };
    this.studentForm = this.formBuilder.group({
      firstName: new FormControl(this.model.User.firstName, [Validators.required, Validators.minLength(3)]),
      lastName: new FormControl(this.model.User.lastName, [Validators.required, Validators.minLength(3)]),
      notificationEmailId: new FormControl(this.model.User.notificationEmailId, [Validators.required, Validators.minLength(10)]),
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

    let address: AddressModel = this.f.studentAddress.value;


  }



}