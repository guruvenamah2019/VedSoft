import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup } from '@angular/forms';


@Component({
    templateUrl: 'header.component.html',
    selector:'ved-admin-header'
})

export class AdminHeaderComponent implements OnInit {
    searchForm:FormGroup;
    constructor(private _router: Router, private _activatedRoute: ActivatedRoute) {
        console.log("AdminHeaderComponent");
        
    }
    ngOnInit() {
    }
    
}