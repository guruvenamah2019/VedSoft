﻿import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import {  CourseService } from 'src/app/core/services';
import { CourseModel } from 'src/app/core/models/master-model';
import { CommonConstants } from 'src/app/core/enums';
import { ToastrService } from 'ngx-toastr';


@Component({
  templateUrl: 'add-course.component.html',
})

export class AddCourseComponent implements OnInit {
  @Input("model")
  model?: CourseModel;
  @Output("onSave")
  onSave: EventEmitter<CourseModel> = new EventEmitter<CourseModel>();

  standardForm: FormGroup;
  loading = false;
  error = '';
  submitted: boolean = false;
  onNavigate() {
  }
  constructor(public bsModalRef: BsModalRef, private formBuilder: FormBuilder, private courseService: CourseService) {

  }
  ngOnInit() {

    this.standardForm = this.formBuilder.group({
      standard: new FormControl(this.model.name, [Validators.required, Validators.minLength(3)]),
      parent: new FormControl(parent, []),
    });


  }


  get f() { return this.standardForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.standardForm.invalid) {
      return;
    }

    let courseInput: CourseModel = {
      name: this.f.standard.value,
      userId: this.courseService.userSerice.loggedUser.id,
      id: this.model.id
    };

    if (this.model.id > 0) {
      this.editStandard(courseInput);
    }
    else {
      this.addStandard(courseInput);
    }

  }

  addStandard(courseInput: CourseModel) {
    this.courseService.addCourse(courseInput).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.courseService.baseService.successMessage("Standard Added sucessfully");
          courseInput.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(courseInput);
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.courseService.baseService.errorMessage("Standard already exist");
        }
        else {
          this.courseService.baseService.errorMessage("Standard unable to add, please try later");
        }

      }

    });

  }

  editStandard(courseInput: CourseModel) {
    this.courseService.updateCourse(courseInput).subscribe(x => {
      if (x.responseData != null) {
        if (x.responseData.statusId == CommonConstants.success) {
          this.courseService.baseService.successMessage("Standard update sucessfully");
          courseInput.id = x.responseData.primaryKey;
          this.bsModalRef.hide();
          this.onSave.emit(courseInput);
        }
        else if (x.responseData.statusId == CommonConstants.duplicateRecord) {
          this.courseService.baseService.errorMessage("Standard already exist with this name");
        }
        else {
          this.courseService.baseService.errorMessage("Standard unable to update, please try later");
        }

      }

    });

  }

}