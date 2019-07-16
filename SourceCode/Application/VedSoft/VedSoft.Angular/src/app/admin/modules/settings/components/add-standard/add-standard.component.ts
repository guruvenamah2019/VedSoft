import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
    templateUrl: 'add-standard.component.html',
})

export class AddStandardComponent implements OnInit {

    onNavigate() {
    }
    constructor(private bsModalRef: BsModalRef) {
        console.log("AdminDashboardIndexComponent");
        
    }
    ngOnInit() {
    }
    
}