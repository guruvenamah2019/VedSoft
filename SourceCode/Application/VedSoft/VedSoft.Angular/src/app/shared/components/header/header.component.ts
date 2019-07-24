import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import jQuery from "jquery"


@Component({
    templateUrl: 'header.component.html',
    selector:'ved-header'
})

export class HeaderComponent implements OnInit {
    searchForm:FormGroup;
    constructor(  private formBuilder: FormBuilder) {
        console.log("HeaderComponent");
        
    }
    ngOnInit() {
        this.searchForm = this.formBuilder.group({
          searchKey: ['', Validators.required]
        });
    
      }
      get f() { return this.searchForm.controls; }

      mobieViewClieck() {
        jQuery(".page-body").toggleClass("sidebar-collpased");
      }
      
}