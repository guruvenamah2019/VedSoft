import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services';
import jQuery from "jquery"


@Component({
    templateUrl: 'branch-sidebar.component.html',
    selector: 'ved-brc-sidebar'
})

export class BranchSidebarComponent implements OnInit {

    constructor(private _router: Router, private _activatedRoute: ActivatedRoute, private auth: AuthenticationService) {
        console.log("BranchSidebarComponent");

    }
    ngOnInit() {

    }

    signOut() {
        this.auth.logout().subscribe(x => {
            if (x) {
                this._router.navigate(["/public/login"]);
            }

        })

    }

    get userName(): string {

        return this.auth.loggedUser.firstName + " " + this.auth.loggedUser.middleName + " " + this.auth.loggedUser.lastName;


    }

    mobieViewClieck() {
        //jQuery(".page-body").toggleClass("sidebar-collpased");
        jQuery("body").toggleClass("sidebar-toggled");
        jQuery(".sidebar").toggleClass("toggled");
        if (jQuery(".sidebar").hasClass("toggled")) {
            jQuery('.sidebar .collapse').collapse('hide');
        };
    }

}