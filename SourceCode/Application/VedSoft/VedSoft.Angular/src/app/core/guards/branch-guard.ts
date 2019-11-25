import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, Router, RouterStateSnapshot, ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import { BranchService, BaseService } from "../services/index";
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BranchGuard implements CanActivate {

  constructor(private router: Router, private baseService: BaseService, ) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
    return this.baseService.branchInfo != null && this.baseService.branchInfo.id > 0;
  }


}
