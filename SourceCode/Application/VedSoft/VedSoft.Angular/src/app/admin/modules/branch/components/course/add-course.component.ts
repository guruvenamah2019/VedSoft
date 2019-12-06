import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CourseService, SubjectHiearchyService } from 'src/app/core/services';
import { CourseModel, SubjectHiearchyModel } from 'src/app/core/models/master-model';
import { CommonConstants } from 'src/app/core/enums';
import { ToastrService } from 'ngx-toastr';


@Component({
  templateUrl: 'add-course.component.html',
})

export class AddBranchCourseComponent implements OnInit {
  @Input("model")
  model?: CourseModel;
  @Output("onSave")
  onSave: EventEmitter<CourseModel> = new EventEmitter<CourseModel>();

  courseForm: FormGroup;
  loading = false;
  error = '';
  submitted: boolean = false;
  subjectList: SubjectHiearchyModel[] = [];
  onNavigate() {
  }
  constructor(public bsModalRef: BsModalRef, private formBuilder: FormBuilder, private courseService: CourseService, private subject: SubjectHiearchyService) {

    var sub: SubjectHiearchyModel = new SubjectHiearchyModel();
    sub.hierarchyLevel = 1;
    var searchInput = subject.baseService.getSearchRequestModel(sub);
    searchInput.pageNumber = 1;
    searchInput.pageSize = 100;

    this.subject.getSubjectHierarchy(searchInput).subscribe(x => {

      this.subjectList = x;

    });

  }
  ngOnInit() {



    this.courseForm = this.formBuilder.group({
      name: new FormControl(this.model.name, [Validators.required, Validators.minLength(3)]),
      courseCost: new FormControl(this.model.courseCost, [Validators.required, Validators.minLength(3)]),
      durationUOM: new FormControl(this.model.durationUOM, [Validators.required, Validators.minLength(3)]),
      //courseDescription: new FormControl(this.model.courseDescription, [Validators.required, Validators.minLength(3)]),

    });


  }


  get f() { return this.courseForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.courseForm.invalid) {
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