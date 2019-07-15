import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
    templateUrl: 'footer.component.html',
    selector:'ved-admin-footer'
})

export class AdminFooterComponent implements OnInit {

    constructor(private _router: Router, private _activatedRoute: ActivatedRoute) {
        console.log("AdminFooterComponent");
        
    }
    ngOnInit() {
    }
    
}