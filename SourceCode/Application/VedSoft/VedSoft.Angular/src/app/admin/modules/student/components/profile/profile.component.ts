import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { BankService, AuthenticationService, StudentService } from '../../../../../core/services';
import { AddressModel } from '../../../../../core/models/master-model';
import { StudentBaseModel, StudentAdmissionModel } from '../../../../../core/models/student-model';
import { CommonConstants } from '../../../../../core/enums';


@Component({
  templateUrl: 'profile.component.html',
  selector: 'ved-std-profile'

})

export class StudentProfileComponent implements OnInit {

  loading = false;
  error = '';
  submitted: boolean = false;
  studentForm: FormGroup;
  model: StudentAdmissionModel = new StudentAdmissionModel();
  onNavigate() {
  }
  constructor(private userService: AuthenticationService, private formBuilder: FormBuilder, private studentService:StudentService ) {
    console.log("StudentProfileComponent");

  }
  ngOnInit() {
    this.model = {
      studentDetails:{
        studentId:0,
        firstName:'',
        middleName:'',
        lastName:'',
        primaryContact:'',
        father:{
          firstName:'',
          lastName:''
        },
        mother:{
          firstName:'',
          lastName:''
        },
        
      },
      guardianDetails:{
        firstName:'',
        lastName:''
      }
      
    };
    this.studentForm = this.formBuilder.group({
      firstName: new FormControl(this.model.studentDetails.firstName, [Validators.required, Validators.minLength(3)]),
      middleName: new FormControl(this.model.studentDetails.middleName ),
      lastName: new FormControl(this.model.studentDetails.lastName, [Validators.required, Validators.minLength(3)]),
      contactNumber: new FormControl("", [Validators.required, Validators.minLength(3)]),
      notificationEmailId: new FormControl(this.model.studentDetails.notificationId, [Validators.required, Validators.minLength(10)]),
      fatherFirstName: new FormControl(this.model.studentDetails.father.firstName, [Validators.required, Validators.minLength(3)]),
      fatherLastName: new FormControl(this.model.studentDetails.father.lastName, [Validators.required, Validators.minLength(3)]),
      motherFirstName: new FormControl(this.model.studentDetails.mother.firstName, [Validators.required, Validators.minLength(3)]),
      motherLastName: new FormControl(this.model.studentDetails.mother.lastName, [Validators.required, Validators.minLength(3)]),
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
    var input: StudentAdmissionModel={
      studentDetails:{
        studentId:0,
        //userName:this.getRandomId(),
        firstName: this.f.firstName.value,
        lastName: this.f.lastName.value,
        middleName: this.f.middleName.value,
        notificationId: this.f.notificationEmailId.value,
        primaryContact:this.f.contactNumber.value,
        mother:{
          firstName: this.f.motherFirstName.value,
          lastName: this.f.motherLastName.value,
        },
        father:{
          firstName: this.f.fatherFirstName.value,
          lastName: this.f.fatherLastName.value,
        },
        //a: JSON.stringify(address),
      },
     
      //actionUserId: this.userService.loggedUser.id
    };
    if(input.studentDetails.studentId>0)
    {
      this.editStudent(input);
    }
    else{
      this.addStudent(input);

    }
    


  }

  addStudent(studentInput: StudentAdmissionModel) {
    this.studentService.addStudent(studentInput).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.studentService.baseService.successMessage("Student Added sucessfully");
          studentInput.studentDetails.studentId = x.responseData.primaryKey;
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

  editStudent(studentInput: StudentAdmissionModel) {
    this.studentService.updateStudent(studentInput).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.studentService.baseService.successMessage("Student update sucessfully");
          studentInput.studentDetails.studentId = x.responseData.primaryKey;
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