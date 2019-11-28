import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import jQuery from "jquery"
import { AuthenticationService } from 'src/app/core/services';


@Component({
    templateUrl: 'header.component.html',
    selector:'ved-header'
})

export class HeaderComponent implements OnInit {
    constructor( private router: Router, private auth: AuthenticationService) {
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
        //jQuery(".page-body").toggleClass("sidebar-collpased");
        jQuery("body").toggleClass("sidebar-toggled");
        jQuery(".sidebar").toggleClass("toggled");
        if (jQuery(".sidebar").hasClass("toggled")) {
            jQuery('.sidebar .collapse').collapse('hide');
        };
      }
      signOut() {
        this.auth.logout().subscribe(x => {
            if (x) {
                this.router.navigate(["/public/login"]);
            }

        })

    }
      
}