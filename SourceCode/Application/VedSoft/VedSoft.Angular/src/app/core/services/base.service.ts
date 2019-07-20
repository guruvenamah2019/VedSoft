
import { Injectable, Inject } from "@angular/core";
import { ApplicationModel } from '../models/shared-model';
import { HttpErrorResponse, HttpClient } from "@angular/common/http";
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class BaseService {
  public requestCount: number = 0;
  public appInfo: ApplicationModel;
  constructor(private http: HttpClient) {
    console.log("AppBaseService");
    this.setAppUrl();

  }
  private setAppUrl() {
    this.appInfo = new ApplicationModel();
    this.appInfo.apiUrl = environment.apiUrl;

  }


}
