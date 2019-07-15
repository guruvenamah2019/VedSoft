import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
    templateUrl: 'header.component.html',
    selector:'ved-admin-header'
})

export class AdminHeaderComponent implements OnInit {

    constructor(private _router: Router, private _activatedRoute: ActivatedRoute) {
        console.log("AdminHeaderComponent");
        
    }
    ngOnInit() {
    }
    
}