import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap, map } from 'rxjs/operators';
import {  AuthenticationService } from 'src/app/core/services';


@Component({
    templateUrl: 'student-index.component.html',
})

export class StudentIndexComponent implements OnInit {
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
        private router: Router,private user: AuthenticationService) {
        console.log("BranchIndexComponent");
        
    }
    ngOnInit() {
        

    }
    
}