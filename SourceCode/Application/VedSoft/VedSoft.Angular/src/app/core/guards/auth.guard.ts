import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from "../services/index";
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthenticationService, private router: Router) { }

  
  
  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {

    let isAuth = this.authService.isLoggedIn();
   
    if(!isAuth)
    {
      this.router.navigate(['/public/login']);
      return of(false);
    }
   else  if (this.authService.loggedUser !=null && this.authService.loggedUser.id >0) {
    //this.router.navigate(['/admin/dashboard']);
        return of(true);
    }
    else {
      //this.router.navigate(['/admin/dashboard']);
        return this.authService.IsUserAuthenticate();
    };
    
  }

canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this.canActivate(route, state);
}

}
