﻿import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseService } from 'src/app/core/services';


@Component({
    templateUrl: 'admin-index.component.html',
    selector:'ved-public-index'
})

export class AdminIndexComponent implements OnInit {
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
    constructor(private _router: Router, private _activatedRoute: ActivatedRoute, private app:BaseService) {
        console.log("AdminIndexComponent");
        
        
    }
    ngOnInit() {
    }
    
}