import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services';


@Component({
    templateUrl: 'sidebar.component.html',
    selector: 'ved-admin-sidebar'
})

export class AdminSidebarComponent implements OnInit {

    constructor(private _router: Router, private _activatedRoute: ActivatedRoute, private auth: AuthenticationService) {
        console.log("AdminIndexComponent");

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

    get userName():string{

        return this.auth.loggedUser.firstName +" "+this.auth.loggedUser.middleName+" " +this.auth.loggedUser.lastName; 


    }

}