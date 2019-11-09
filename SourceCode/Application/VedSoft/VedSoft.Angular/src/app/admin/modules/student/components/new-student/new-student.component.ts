import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { BankService, AuthenticationService } from 'src/app/core/services';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Component({
  templateUrl: 'new-student.component.html',
})



export class NewStudentComponent implements OnInit {
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
          label: 'Student Details',
          link: './profile',
          index: 0
      }, {
          label: 'Guardian Details',
          link: './enquiry',
          index: 1
      }, {
          label: 'Admission Details',
          link: './admission',
          index: 2
      }, 
      {
        label: 'Payment Details',
        link: './performance',
        index: 3
    }, 
    {
      label: 'Batch Details',
      link: './batch',
      index: 4
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