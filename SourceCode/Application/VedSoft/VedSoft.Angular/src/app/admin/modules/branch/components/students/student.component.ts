import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { BankService, AuthenticationService } from 'src/app/core/services';
import { BankModel } from 'src/app/core/models/master-model';
import { CommonConstants } from 'src/app/core/enums';
import { ToastrService } from 'ngx-toastr';


@Component({
  templateUrl: 'student.component.html',
})

export class StudentComponent implements OnInit {
  @Input("model")
  model?: BankModel;
  @Output("onSave")
  onSave: EventEmitter<BankModel> = new EventEmitter<BankModel>();

  bankForm: FormGroup;
  loading = false;
  error = '';
  submitted: boolean = false;
  onNavigate() {
  }
  constructor(private userService: AuthenticationService) {
    console.log("AdminDashboardIndexComponent");

  }
  ngOnInit() {


  }
  

}