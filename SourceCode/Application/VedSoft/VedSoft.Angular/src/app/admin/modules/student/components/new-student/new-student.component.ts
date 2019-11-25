import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { BankService, AuthenticationService } from 'src/app/core/services';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { StudentProfileComponent } from '..';


@Component({
  templateUrl: 'new-student.component.html',
})



export class NewStudentComponent implements OnInit {
  navLinks: any[];
  activeLinkIndex = -1;
  branchId=0;
  @ViewChild(StudentProfileComponent,{static:false}) stepOneComponent: StudentProfileComponent;
  @ViewChild(StudentProfileComponent,{static:false}) stepTwoComponent: StudentProfileComponent;
  @ViewChild(StudentProfileComponent,{static:false}) stepThreeComponent: StudentProfileComponent;


  get frmStepOne() {
     return this.stepOneComponent ? this.stepOneComponent.studentForm : null;
  }

  get frmStepTwo() {
     return this.stepTwoComponent ? this.stepTwoComponent.studentForm : null;
  }

  get frmStepThree() {
     return this.stepThreeComponent ? this.stepThreeComponent.studentForm : null;
  }
  
  onNavigate() {
  }
  constructor(private userService: AuthenticationService, private router: Router,private activatedRoute: ActivatedRoute) {
    console.log("StudentComponent");

    this.activatedRoute.parent.params.subscribe(params => {
      console.log(params)
      if (params["branchId"] != null) {
          this.branchId = params["branchId"];
          
      }
    });

   
  }
  ngOnInit() {


    this.router.events.subscribe((res) => {

//      this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === '.' + this.router.url));

  });


  }
  navigate(event: MatTabChangeEvent) {
    const tabData = this.navLinks[event.index];    
   this.router.navigate([tabData.link], { relativeTo: this.activatedRoute });
}
  

}