import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { BankService, AuthenticationService, StudentService } from 'src/app/core/services';
import { AddressModel } from 'src/app/core/models/master-model';
import { StudentModel } from 'src/app/core/models/student-model';
import { CommonConstants } from 'src/app/core/enums';


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
  constructor(private userService: AuthenticationService, private formBuilder: FormBuilder, private studentService:StudentService ) {
    console.log("StudentProfileComponent");

  }
  ngOnInit() {
    this.model = {
      Id:0,
      User: {
        firstName:'',
        lastName:'',
        address:'',
        notificationEmailId:'',
        
      },
    };
    this.studentForm = this.formBuilder.group({
      firstName: new FormControl(this.model.User.firstName, [Validators.required, Validators.minLength(3)]),
      middleName: new FormControl(this.model.User.middleName ),
      lastName: new FormControl(this.model.User.lastName, [Validators.required, Validators.minLength(3)]),
      contactNumber: new FormControl("", [Validators.required, Validators.minLength(3)]),
      notificationEmailId: new FormControl(this.model.User.notificationEmailId, [Validators.required, Validators.minLength(10)]),
      fatherFirstName: new FormControl(this.model.User.firstName, [Validators.required, Validators.minLength(3)]),
      fatherLastName: new FormControl(this.model.User.lastName, [Validators.required, Validators.minLength(3)]),
      motherFirstName: new FormControl(this.model.User.firstName, [Validators.required, Validators.minLength(3)]),
      motherLastName: new FormControl(this.model.User.lastName, [Validators.required, Validators.minLength(3)]),
      //parent: new FormControl(parent, []),
    });

  }

  private addFormControl(name: string, formGroup: FormGroup): void {
    this.studentForm.addControl(name, formGroup);
  }

  get f() { return this.studentForm.controls; }

  private getRandomId() {
    return (Math.floor((Math.random()*6)+1)).toString();
  }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.studentForm.invalid) {
      return;
    }
    

    let address: AddressModel = this.f.studentAddress.value;
    var input: StudentModel={
      Id: this.model.Id,
      User:{
        userName:this.getRandomId(),
        firstName: this.f.firstName.value,
        lastName: this.f.lastName.value,
        middleName: this.f.middleName.value,
        notificationEmailId: this.f.notificationEmailId.value,
        contactNumber:this.f.contactNumber.value,
        address: JSON.stringify(address),
      },
      MotherUser:{
        firstName: this.f.motherFirstName.value,
        lastName: this.f.motherLastName.value,
      },
      FatherUser:{
        firstName: this.f.fatherFirstName.value,
        lastName: this.f.fatherLastName.value,
      },
      ActionUserId: this.userService.loggedUser.id
    };
    if(input.Id>0)
    {
      this.editStudent(input);
    }
    else{
      this.addStudent(input);

    }
    


  }

  addStudent(studentInput: StudentModel) {
    this.studentService.addStudent(studentInput).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.studentService.baseService.successMessage("Student Added sucessfully");
          studentInput.Id = x.responseData.primaryKey;
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.studentService.baseService.errorMessage("Student already exist");
        }
        else {
          this.studentService.baseService.errorMessage("Student unable to add, please try later");
        }

      }

    });

  }

  editStudent(studentInput: StudentModel) {
    this.studentService.updateStudent(studentInput).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.studentService.baseService.successMessage("Student update sucessfully");
          studentInput.Id = x.responseData.primaryKey;
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.studentService.baseService.errorMessage("Student already exist with this name");
        }
        else {
          this.studentService.baseService.errorMessage("Student unable to update, please try later");
        }

      }

    });

  }



}