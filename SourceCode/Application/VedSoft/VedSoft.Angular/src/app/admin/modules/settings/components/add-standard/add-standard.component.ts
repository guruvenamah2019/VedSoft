import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
    this.standardForm = this.formBuilder.group({
      standard: [this.model.name, Validators.required]
    });

  }


  get levelName():string{

    let levelName= this.courseService.getLevelName(this.model.hierarchyLevel);

    
    return levelName;
}

get parentLevelName():string{
    let levelName= this.courseService.getLevelName(this.model.hierarchyLevel-1);
    return levelName;

}

  get f() { return this.standardForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.standardForm.invalid) {
      return;
    }
    let courseInput: CourseHiearchyModel = {
      parentId: this.model.parentId,
      name: this.f.standard.value,
      userId: this.courseService.userSerice.loggedUser.id,
      hierarchyLevel: this.model.hierarchyLevel,
      id: this.model.id
    };
   
if(this.model.id>0)
{
  this.editStandard(courseInput);
}
else {
  this.addStandard(courseInput);
}

  }

  addStandard(courseInput:CourseHiearchyModel){
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

  editStandard(courseInput:CourseHiearchyModel){
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