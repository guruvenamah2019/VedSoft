import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, Router, RouterStateSnapshot, ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import {  BranchService } from "../services/index";
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BranchGuard implements CanActivate {

  constructor(private branchService: BranchService, private router: Router, private route: ActivatedRoute) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean>  {
   let branchId = this.route.data.subscribe(x=> console.log(x));
        return of(true);
  }

   
}
