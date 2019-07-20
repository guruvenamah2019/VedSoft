import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
    templateUrl: 'public-index.component.html',
    selector:'ved-public-index'
})

export class PublicIndexComponent implements OnInit {
    pageTitle: string = "login";
    id: string;
   
    onNavigate() {
        this._router.navigate(['/'], { queryParams: { "ram": 1 } });
    }
    constructor(private _router: Router, private _activatedRoute: ActivatedRoute) {
        console.log("LoginIndexComponent");
        
    }
    ngOnInit() {
    }
    
}
