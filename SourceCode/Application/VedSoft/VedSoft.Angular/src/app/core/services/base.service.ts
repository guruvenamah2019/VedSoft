
import { Injectable, Inject } from "@angular/core";
import { ApplicationModel, RequestModel, SearchRequestModel, ResponseModel } from '../models/shared-model';
import { HttpErrorResponse, HttpClient } from "@angular/common/http";
import { environment } from '../../../environments/environment';
import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { CustomerModel } from '../models/master-model/customer-model';
import { LOGIN_SERVICE_URL, COURSE_SERVICE_URL } from '../constant/service-url';
import { map, catchError } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class BaseService {
  public requestCount: number = 0;
  public appInfo: ApplicationModel;
  public CustomerInfo: CustomerModel;
  constructor(private http: HttpClient, private messageService: ToastrService) {
    console.log("AppBaseService");
    this.setAppUrl();

    //this.getCustomer(subDomainName).subscribe()

  }
  private setAppUrl() {
    this.appInfo = new ApplicationModel();
    this.appInfo.apiUrl = environment.apiUrl;

  }

  public getRequestModel<T>(requestModel: T): RequestModel<T> {
    var obj: RequestModel<T> = new RequestModel<T>();
    obj.CustomerId = this.CustomerInfo.customerId,
      obj.LanguageId = this.appInfo.LanguageId,
      obj.requestParameter = requestModel;
    return obj;

  }

  public getSearchRequestModel<T>(requestModel: T): SearchRequestModel<T> {
    var obj: SearchRequestModel<T> = new SearchRequestModel<T>();
    obj.CustomerId = this.CustomerInfo.customerId,
      obj.LanguageId = this.appInfo.LanguageId,
      obj.requestParameter = requestModel;
    return obj;

  }

  public successMessage(message: string) {

    this.messageService.success(message);
  }
  public errorMessage(message: string) {

    this.messageService.error(message);
  }
  public warningMessage(message: string) {
    this.messageService.warning(message);
  }

  public getCustomer(subDomain: string): Observable<boolean> {
    
    /*this.CustomerInfo ={
      customerId:1,
      name:"Ram",
      contactNumber:"111111",
      code:"1111"
    };*/

    if (this.CustomerInfo && this.CustomerInfo.customerId) {
      return of(true);
    }
    else {

      let urlName:string = window.location.hostname;
      subDomain = "cust-01";
      let input: RequestModel<CustomerModel> = {
        CustomerId: 0,
        LanguageId: this.appInfo.LanguageId,
        requestParameter: {
          subDomain: subDomain
        }
      };

      let url = `${this.appInfo.apiUrl}/${COURSE_SERVICE_URL.ACTION_GET_CUSTOMER_DETAILS_BY_SUB_DOMAIN}`;

      return this.http.post<ResponseModel<CustomerModel>>(url, input)
        .pipe(
          map(cust => {
            if (cust != null && cust.responseData != null) {
              this.CustomerInfo = cust.responseData;
              return true
            }
            else {
              return false;
            }

          }),
          catchError(error => {
            return of(false);
          }));
    }
  }

}
