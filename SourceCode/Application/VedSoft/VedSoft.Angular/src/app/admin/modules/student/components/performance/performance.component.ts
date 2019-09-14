import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { BankService, AuthenticationService } from 'src/app/core/services';


@Component({
  templateUrl: 'performance.component.html',
  selector:'ved-std-performance'

})

export class StudentPerformanceComponent implements OnInit {

  loading = false;
  error = '';
  submitted: boolean = false;
  onNavigate() {
  }
  constructor(private userService: AuthenticationService) {
    console.log("StudentPerformanceComponent");

  }
  ngOnInit() {


  }
  

}