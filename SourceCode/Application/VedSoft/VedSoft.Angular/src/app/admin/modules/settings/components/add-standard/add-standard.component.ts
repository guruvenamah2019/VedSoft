import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CourseHiearchyService, BaseService, AuthenticationService } from 'src/app/core/services';
import { CourseHiearchyModel } from 'src/app/core/models/master-model/course-hiearchy.model';
import { CommonConstants } from 'src/app/core/enums';
import { ToastrService } from 'ngx-toastr';


@Component({
  templateUrl: 'add-standard.component.html',
})

export class AddStandardComponent implements OnInit {
  @Input("model")
  model?: CourseHiearchyModel;
  @Output("onSave")
  onSave: EventEmitter<CourseHiearchyModel> = new EventEmitter<CourseHiearchyModel>();

  standardForm: FormGroup;
  loading = false;
  error = '';
  submitted: boolean = false;
  onNavigate() {
  }
  constructor(private bsModalRef: BsModalRef, private formBuilder: FormBuilder, private courseService: CourseHiearchyService) {
    console.log("AdminDashboardIndexComponent");

  }
  ngOnInit() {

    let parent = this.courseService.CourseHiearchy.filter(x => x.id == this.model.parentId);
    parent = parent.length == 0 ? null : parent;


    this.standardForm = this.formBuilder.group({
      standard: new FormControl(this.model.name, [Validators.required, Validators.minLength(3)]),
      parent: new FormControl(parent, []),
    });

    if (this.model.id == 0 && this.model.hierarchyLevel > 1) {
      this.standardForm.controls.parent.setValidators([Validators.required]);
    }



  }


  get levelName(): string {

    let levelName = this.courseService.getLevelName(this.model.hierarchyLevel);


    return levelName;
  }



  getParentList() {

    return this.courseService.CourseHiearchy.filter(x => x.hierarchyLevel == (this.model.hierarchyLevel - 1));

  }

  get parentLevelName(): string {
    let levelName = this.courseService.getLevelName(this.model.hierarchyLevel - 1);
    return levelName;

  }

  get f() { return this.standardForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.standardForm.invalid) {
      return;
    }
    let parent: CourseHiearchyModel = this.model.id > 0 ? this.courseService.CourseHiearchy.find(x => x.id == this.model.parentId) : this.f.parent.value;

    let courseInput: CourseHiearchyModel = {
      parentId: parent? parent.id:0,
      name: this.f.standard.value,
      userId: this.courseService.userSerice.loggedUser.id,
      hierarchyLevel: this.model.hierarchyLevel,
      id: this.model.id
    };

    if (this.model.id > 0) {
      this.editStandard(courseInput);
    }
    else {
      this.addStandard(courseInput);
    }

  }

  addStandard(courseInput: CourseHiearchyModel) {
    this.courseService.addCourseHierarchy(courseInput).subscribe(x => {
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

  editStandard(courseInput: CourseHiearchyModel) {
    this.courseService.updateCourseHierarchy(courseInput).subscribe(x => {
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