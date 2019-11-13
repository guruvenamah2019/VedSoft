import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { BankService, AuthenticationService, BranchService } from 'src/app/core/services';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Component({
  templateUrl: 'student.component.html',
})



export class StudentComponent implements OnInit {
  navLinks: any[];
  activeLinkIndex = -1;

  loading = false;
  error = '';
  submitted: boolean = false;
  branchId:number=0;
  onNavigate() {
  }
  constructor(private userService: AuthenticationService, private router: Router,private route: ActivatedRoute, private branchService:BranchService) {
    console.log("StudentComponent");

    this.route.parent.params.subscribe(params => {
      console.log(params)
      if (params["branchId"] != null) {
          this.branchId = params["branchId"];
          this.branchService.getBranchInfo(this.branchId).subscribe(x => {
              if (x != null) {
                this.route.params.subscribe(childParams => {
                  console.log(childParams)
                });
              }


          })
      }


  }); // Object {artistId: 12345}

   


    this.navLinks = [
      {
          label: 'Profile',
          link: './profile',
          index: 0
      }, {
          label: 'Enquiry',
          link: './enquiry',
          index: 1
      }, {
          label: 'Admission',
          link: './admission',
          index: 2
      }, 
      {
        label: 'Performance',
        link: './performance',
        index: 3
    }, 
    {
      label: 'Attendance',
      link: './attendance',
      index: 4
  }, 
  {
    label: 'Punches',
    link: './punches',
    index: 5
}, 
{
  label: 'Batch',
  link: './batch',
  index: 6
}, 
{
  label: 'Academic',
  link: './academic',
  index: 7
}, 
{
  label: 'Leaves',
  link: './leaves',
  index: 8
},
{
  label: 'Login',
  link: './login',
  index: 9
},
{
  label: 'Documents',
  link: './documents',
  index: 10
},
{
  label: 'Assignments',
  link: './assignments',
  index: 11
}, 
  ];

  }
  ngOnInit() {


    this.router.events.subscribe((res) => {

      this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === '.' + this.router.url));

  });


  }
  navigate(event: MatTabChangeEvent) {
    const tabData = this.navLinks[event.index];    
   this.router.navigate([tabData.link], { relativeTo: this.route });
}
  

}