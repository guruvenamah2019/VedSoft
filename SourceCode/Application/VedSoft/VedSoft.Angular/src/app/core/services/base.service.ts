
import { Injectable, Inject } from "@angular/core";
import { ApplicationModel, RequestModel, SearchRequestModel } from '../models/shared-model';
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

  public getRequestModel<T>(requestModel:T):RequestModel<T>{
    var obj:RequestModel<T> = new RequestModel<T>();
    obj.CustomerId= this.appInfo.CustomerId,
    obj.LanguageId= this.appInfo.LanguageId,
    obj.requestParameter = requestModel;
    return obj;

  }

  public getSearchRequestModel<T>(requestModel:T):SearchRequestModel<T>{
    var obj:SearchRequestModel<T> = new SearchRequestModel<T>();
    obj.CustomerId= this.appInfo.CustomerId,
    obj.LanguageId= this.appInfo.LanguageId,
    obj.requestParameter = requestModel;
    return obj;

  }

}
