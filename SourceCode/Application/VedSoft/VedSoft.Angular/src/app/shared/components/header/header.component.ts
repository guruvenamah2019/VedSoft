import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import jQuery from "jquery"


@Component({
    templateUrl: 'header.component.html',
    selector:'ved-header'
})

export class HeaderComponent implements OnInit {
    constructor( private router: Router) {
        console.log("HeaderComponent");
        //router..subscribe(x=>{console.log("RAM"+ router.url)})

        
    }

    public activeUrl(){
      return this.router.url;
    }
    get IsBranch(){
      return this.router.url.toLowerCase().indexOf("/admin/branchs/")>-1;
    }

    ngOnInit() {
      
    
      }
     

      mobieViewClieck() {
        jQuery(".page-body").toggleClass("sidebar-collpased");
      }
      
}