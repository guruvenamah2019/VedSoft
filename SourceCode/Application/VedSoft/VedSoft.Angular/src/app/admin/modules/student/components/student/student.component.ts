import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { BankService, AuthenticationService } from 'src/app/core/services';
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
  onNavigate() {
  }
  constructor(private userService: AuthenticationService, private router: Router,private activatedRoute: ActivatedRoute) {
    console.log("StudentComponent");

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
   this.router.navigate([tabData.link], { relativeTo: this.activatedRoute });
}
  

}