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
  submitted: boolean = true;
  studentForm: FormGroup;
  dateFilter = (d: Date): boolean => {
    const day = d.getDay();
    const today = new Date();
    // Prevent Saturday and Sunday from being selected.
    return d <= today;
  }
  model: StudentAdmissionModel = new StudentAdmissionModel();
  onNavigate() {
  }
  constructor(private userService: AuthenticationService, private formBuilder: FormBuilder, private studentService: StudentService) {
    console.log("StudentProfileComponent");

  }
  ngOnInit() {
    this.model = {
      studentDetails: {
        studentId: 0,
        firstName: '',
        middleName: '',
        lastName: '',
        primaryContact: '',
        father: {
          firstName: '',
          lastName: ''
        },
        mother: {
          firstName: '',
          lastName: ''
        },
        details: {
          address: {
            address1: ''
          }
        }


      },
      guardianDetails: {
        firstName: '',
        lastName: ''
      }

    };
    this.studentForm = this.formBuilder.group({
      firstName: new FormControl(this.model.studentDetails.firstName, [Validators.required, Validators.minLength(2)]),
      middleName: new FormControl(this.model.studentDetails.middleName),
      lastName: new FormControl(this.model.studentDetails.lastName, [Validators.required, Validators.minLength(2)]),
      contactNumber: new FormControl("", [Validators.required, Validators.minLength(6), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]),
      notificationEmailId: new FormControl(this.model.studentDetails.notificationId, [Validators.email]),
      fatherFirstName: new FormControl(this.model.studentDetails.father.firstName, [Validators.required, Validators.minLength(2)]),
      fatherLastName: new FormControl(this.model.studentDetails.father.lastName, []),
      fatherMiddleName: new FormControl(this.model.studentDetails.father.middleName),
      fatherContactNumber: new FormControl("", [Validators.required, , Validators.minLength(6), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]),
      fatherNotificationEmailId: new FormControl(this.model.studentDetails.notificationId, [Validators.email]),
      motherFirstName: new FormControl(this.model.studentDetails.mother.firstName, [Validators.required, Validators.minLength(2)]),
      motherLastName: new FormControl(this.model.studentDetails.mother.lastName, []),
      motherMiddleName: new FormControl(this.model.studentDetails.mother.middleName),
      motherContactNumber: new FormControl("", [Validators.required, Validators.minLength(6), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]),
      motherNotificationEmailId: new FormControl(this.model.studentDetails.mother.notificationId, [Validators.email]),
      dateOfBirth: new FormControl(this.model.studentDetails.dateOfBirth, []),


      guardianFirstName: new FormControl(this.model.guardianDetails.firstName, [Validators.required, Validators.minLength(2)]),
      guardianMiddleName: new FormControl(this.model.guardianDetails.middleName),
      guardianLastName: new FormControl(this.model.guardianDetails.lastName, []),
      guardianContactNumber: new FormControl("", [Validators.required, Validators.minLength(6), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]),
      guardianNotificationEmailId: new FormControl(this.model.guardianDetails.notificationId, [Validators.email]),

      //parent: new FormControl(parent, []),
    });

  }

  private addFormControl(name: string, formGroup: FormGroup): void {
    this.studentForm.addControl(name, formGroup);
  }

  get f() { return this.studentForm.controls; }

  private getRandomId() {
    return (Math.floor((Math.random() * 6) + 1)).toString();
  }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.studentForm.invalid) {
      return;
    }


    let address: AddressModel = this.f.studentAddress.value;
    var input: StudentAdmissionModel = {
      customerId: this.userService.baseService.CustomerInfo.customerId,
      branchId: this.userService.baseService.branchInfo.id,
      academicInstituteId: 1,
      isEnrolled: 1,
      studentDetails: {
        studentId: 0,
        loginId: '',
        password: '',
        //userName:this.getRandomId(),
        firstName:this.convertNullToBlack( this.f.firstName.value),
        lastName:this.convertNullToBlack( this.f.lastName.value),
        middleName:this.convertNullToBlack( this.f.middleName.value),
        notificationId: this.convertNullToBlack(this.f.notificationEmailId.value),
        primaryContact: this.convertNullToBlack(this.f.contactNumber.value),
        dateOfBirth: this.f.dateOfBirth.value,
        mother: {
          firstName:this.convertNullToBlack( this.f.motherFirstName.value),
          lastName:this.convertNullToBlack( this.f.motherLastName.value),
          middleName: this.convertNullToBlack(this.f.motherMiddleName.value),
          primaryContact:this.convertNullToBlack( this.f.motherContactNumber.value),
          notificationId:this.convertNullToBlack( this.f.motherNotificationEmailId.value),
        },
        father: {
          firstName: this.convertNullToBlack(this.f.fatherFirstName.value),
          lastName: this.convertNullToBlack(this.f.fatherLastName.value),
          middleName: this.convertNullToBlack(this.f.fatherMiddleName.value),
          primaryContact: this.convertNullToBlack(this.f.fatherContactNumber.value),
          notificationId:this.convertNullToBlack( this.f.fatherNotificationEmailId.value),
        },
        details: {
          address: address,

        }

      },
      guardianDetails: {
        firstName: this.convertNullToBlack(this.f.guardianFirstName.value),
        lastName: this.convertNullToBlack(this.f.guardianLastName.value),
        middleName: this.convertNullToBlack(this.f.guardianMiddleName.value),
        primaryContact: this.convertNullToBlack(this.f.guardianContactNumber.value),
        notificationId: this.convertNullToBlack(this.f.guardianNotificationEmailId.value),
        loginId: '',
        password: ''

      }

      //actionUserId: this.userService.loggedUser.id
    };



    if (input.studentDetails.studentId > 0) {
      this.editStudent(input);
    }
    else {
      this.addStudent(input);

    }



  }

  convertNullToBlack(value: any): string {
    return value == null ? '' : value;
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