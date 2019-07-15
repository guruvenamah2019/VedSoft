import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
    templateUrl: 'sidebar.component.html',
    selector:'ved-admin-sidebar'
})

export class AdminSidebarComponent implements OnInit {
    
    constructor(private _router: Router, private _activatedRoute: ActivatedRoute) {
        console.log("AdminIndexComponent");
        
    }
    ngOnInit() {
    }
    
}