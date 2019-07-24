import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
    templateUrl: 'profile-index.component.html',
    selector:'ved-profile-index'
})

export class ProfileIndexComponent implements OnInit {
   
    onNavigate() {
    }
    constructor() {
        console.log("ProfileIndexComponent");
        
    }
    ngOnInit() {
    }
    
}
