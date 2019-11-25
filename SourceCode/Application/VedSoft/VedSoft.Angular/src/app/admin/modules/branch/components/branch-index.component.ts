import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap, map } from 'rxjs/operators';
import { BranchService } from '../../../../core/services';


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
        private router: Router,private branchService:BranchService) {
        console.log("BranchIndexComponent");
        
    }
    ngOnInit() {
        this.route.params.subscribe(params => {
            this.branchService.baseService.branchInfo=null;
            console.log(params)
            if(params!=null && params.branchId!=null){
                this.branchService.getBranchInfo(params.branchId).subscribe(brc=>{
                    this.branchService.baseService.branchInfo = brc;
                })
            }
        }); // Object {artistId: 12345}

    }
    
}