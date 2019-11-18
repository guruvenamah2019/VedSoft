import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, Router, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import {  BaseService } from "../services/index";
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CustomerGuard implements CanActivate {

  constructor(private baseService: BaseService, private router: Router) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean   {
    let domain = state.url;
        
        return  this.baseService.getCustomer(domain).pipe(map(logged => {
          if(!logged) {
            this.router.navigate(['/401']);
            return false;
          }
          return true;
        }));
       
      }

   
}
