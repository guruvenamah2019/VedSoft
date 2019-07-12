
import { Injectable, Inject } from "@angular/core";
import {  Subject, throwError } from 'rxjs';
import { ModuleUrlModel } from '../models/shared-model';
import { HttpErrorResponse } from "@angular/common/http";
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class BaseService {
    public requestCount: number = 0;
    public appUrl: ModuleUrlModel;
    constructor() {

        console.log("AppBaseService");
        this.setAppUrl();
    }
    private setAppUrl() {
        this.appUrl = new ModuleUrlModel();
      this.appUrl.apiUrl = environment.apiUrl;


        
    }

    public handleError(error:  HttpErrorResponse) {

        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
          } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error(
              `Backend returned code ${error.status}, ` +
              `body was: ${error.error}`);
          }
          // return an observable with a user-facing error message
          return throwError(
            'Something bad happened; please try again later.');
    }

    
}
