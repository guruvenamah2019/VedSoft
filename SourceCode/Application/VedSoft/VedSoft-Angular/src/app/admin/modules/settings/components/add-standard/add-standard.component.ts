import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
    templateUrl: 'add-standard.component.html',
})

export class AddStandardComponent implements OnInit {
    standardForm: FormGroup;
    loading = false;
  error = '';
  submitted:boolean=false;
    onNavigate() {
    }
    constructor(private bsModalRef: BsModalRef,  private formBuilder: FormBuilder) {
        console.log("AdminDashboardIndexComponent");
        
    }
    ngOnInit() {
        this.standardForm = this.formBuilder.group({
          standard: ['', Validators.required]
        });
    
      }
      get f() { return this.standardForm.controls; }

      onSubmit() {
    this.submitted=true;
        // stop here if form is invalid
        if (this.standardForm.invalid) {
          return;
        }
    this.bsModalRef.hide();
       
      }
    }