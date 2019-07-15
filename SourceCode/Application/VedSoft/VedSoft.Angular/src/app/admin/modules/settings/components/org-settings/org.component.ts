import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
    templateUrl: 'org.component.html',
})

export class OrganizationSettingsComponent implements OnInit {
    pageTitle: string = "login";
    id: string;
    //constructor(private _router: Router, private _activatedRoute: ActivatedRoute) {
    //    this.id = _activatedRoute.snapshot.params["id"];
    //}
    //ngOnInit() {
    //}

    onNavigate() {
        this._router.navigate(['/'], { queryParams: { "ram": 1 } });
    }
    constructor(private _router: Router, private _activatedRoute: ActivatedRoute) {
        console.log("AdminDashboardIndexComponent");
        
    }
    ngOnInit() {
    }
    
}