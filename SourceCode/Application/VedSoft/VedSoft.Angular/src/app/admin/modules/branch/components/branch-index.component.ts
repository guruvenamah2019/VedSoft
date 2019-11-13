﻿import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap, map } from 'rxjs/operators';


@Component({
    templateUrl: 'branch-index.component.html',
})

export class BranchIndexComponent implements OnInit {
    pageTitle: string = "login";
    id: string;
    //constructor(private _router: Router, private _activatedRoute: ActivatedRoute) {
    //    this.id = _activatedRoute.snapshot.params["id"];
    //}
    //ngOnInit() {
    //}

    onNavigate() {
    }
    constructor( private route: ActivatedRoute,
        private router: Router,) {
        console.log("BranchIndexComponent");
        
    }
    ngOnInit() {
        this.route.params.subscribe(params => console.log(params)); // Object {artistId: 12345}

    }
    
}