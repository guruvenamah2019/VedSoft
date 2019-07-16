import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AddStandardComponent } from '../add-standard/add-standard.component';



@Component({
    templateUrl: 'standards.component.html',
})

export class StandardsSettingsComponent implements OnInit {
   
    bsModalRef: BsModalRef;
    constructor(private modalService: BsModalService) {
        console.log("AdminDashboardIndexComponent");
        
    }
    ngOnInit() {
    }

    addStandard():void{
        const initialState = {
           // model: model
        };
        this.bsModalRef = this.modalService.show(AddStandardComponent, { ignoreBackdropClick: true, initialState });

    }
    
}