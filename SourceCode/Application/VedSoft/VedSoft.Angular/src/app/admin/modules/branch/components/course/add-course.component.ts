import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CourseService, SubjectHiearchyService } from 'src/app/core/services';
import { CourseModel, SubjectHiearchyModel } from 'src/app/core/models/master-model';
import { CommonConstants } from 'src/app/core/enums';
import { OptionModel } from 'src/app/core/models/shared-model';


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
  //subjectList: SubjectHiearchyModel[] = [];
  @Input("selectedSubjectList")
  selectedSubjectList: SubjectHiearchyModel[];
  durationList: OptionModel[] = [];


  onNavigate() {
  }
  constructor(public bsModalRef: BsModalRef, private formBuilder: FormBuilder, private courseService: CourseService, private subject: SubjectHiearchyService) {

    if(!this.selectedSubjectList)
    this.selectedSubjectList=[];
    var sub: SubjectHiearchyModel = new SubjectHiearchyModel();
    sub.hierarchyLevel = 1;
    var searchInput = subject.baseService.getSearchRequestModel(sub);
    searchInput.pageNumber = 1;
    searchInput.pageSize = 100;

    this.subject.getSubjectHierarchy(searchInput).subscribe(x => {

      /*this.subjectList = x;
      this.subjectList.forEach(item=>{
        item.child = this.subject.SubjectHiearchy.filter(l=>l.parentId == item.id);
      });
      */

    });

  }

  public get SubjectList():SubjectHiearchyModel[]{
    
    var list = this.subject.SubjectHiearchy.filter(x=>x.hierarchyLevel==1);

    list.forEach(item=>{
      item.child=this.getChild(item.id);
      /*
      var child = this.subject.SubjectHiearchy.filter(l=>l.parentId == item.id);
      child.forEach(x=>{
        var childItem = this.selectedSubjectList.find(it=>it.id ==x.id);
        if(childItem==null || childItem ==undefined){
          item.child.push(x);
        }
      });
*/
       //item.child = this.selectedSubjectList.filter(l=>l.parentId == item.id);
     });
     //console.log(list);
     var result = list.filter(x=> x.child!=null&& x.child.length>0);

     //console.log(result);
     return result;
  }

  public getChild(parentId:number):SubjectHiearchyModel[]{
    var item :SubjectHiearchyModel[]=[];
    var child = this.subject.SubjectHiearchy.filter(l=>l.parentId == parentId);
      child.forEach(x=>{
        var childItem = this.selectedSubjectList.find(it=>it.id ==x.id);
        if(childItem==null || childItem ==undefined){
          item.push(x);
        }
      });
      return item;
    }

public get SelectedSubjectList():SubjectHiearchyModel[]{

 var list = this.subject.SubjectHiearchy.filter(x=>x.hierarchyLevel==1);

 list.forEach(item=>{
    item.child = this.selectedSubjectList.filter(l=>l.parentId == item.id);
  });

  list = list.filter(item=> item.child!=null&& item.child.length>0);
  return list;
}

  

  add(sub: SubjectHiearchyModel){
    this.selectedSubjectList.push(sub);

  }
  remove(sub: SubjectHiearchyModel){
    
    var index  =this.selectedSubjectList.findIndex(x=>x.id == sub.id);
    if(index>-1){
      this.selectedSubjectList.splice(index,1);
    }

  }
  ngOnInit() {

this.durationList.push({
  ID:1,
  Text:"Days"
});
this.durationList.push({
  ID:2,
  Text:"Month"
});
this.durationList.push({
  ID:3,
  Text:"Year"
});

let uom = this.durationList.filter(x => x.ID == this.model.durationUOM);
uom = uom.length == 0 ? null : uom;

    this.courseForm = this.formBuilder.group({
      name: new FormControl(this.model.name, [Validators.required, Validators.minLength(3)]),
      courseCost: new FormControl(this.model.courseCost, [Validators.required, Validators.minLength(3)]),
      duration: new FormControl(this.model.duration, [Validators.required, Validators.minLength(1)]),
      durationUOM: new FormControl(uom, [Validators.required]),
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

    let subj = this.selectedSubjectList.map(x=>x.id);

    let courseInput: CourseModel = {
      name: this.f.name.value,
      courseCost: this.f.courseCost.value,
      duration:this.f.duration.value,
      durationUOM:this.f.durationUOM.value.ID,
      userId: this.courseService.userSerice.loggedUser.id,
      id: this.model.id,
      customerSubjectHiearchyIdList: subj,
      courseDescription: this.f.name.value,
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