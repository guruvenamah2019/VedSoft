import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, observable } from 'rxjs';
import { RequestModel, ResponseModel, ResultModel, SearchRequestModel } from '../models/shared-model/index';
import { BaseService } from './base.service';
import { BRANCH_SERVICE_URL } from "../constant/service-url";
import { AuthenticationService } from './authentication.service';
import { map, tap } from 'rxjs/operators';
import { CustomerBranchModel } from '../models/master-model';

@Injectable({
    providedIn: 'root'
})
export class BranchService {

    private branchList: CustomerBranchModel[] = [];

    public get BranchList() {
        return this.branchList;
    }

    constructor(private http: HttpClient, public baseService: BaseService, public userSerice: AuthenticationService) {

    }

    public addBranch(course: CustomerBranchModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<CustomerBranchModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${BRANCH_SERVICE_URL.ACTION_ADD_CUSTOMER_BRANCH}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.branchList = [];
        }));

    }
    public updateBranch(course: CustomerBranchModel): Observable<ResponseModel<ResultModel>> {

        let input: RequestModel<CustomerBranchModel> = this.baseService.getRequestModel(course);

        let url = `${this.baseService.appInfo.apiUrl}/${BRANCH_SERVICE_URL.ACTION_UPDATE_CUSTOMER_BRANCH}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.branchList = [];
        }));

    }
    public getBranchList(input: SearchRequestModel<CustomerBranchModel>): Observable<CustomerBranchModel[]> {
        /*
                this.branchList.push({
                    id:1,
                    name:"Branch 1",
                    code:"BPL-1",
                    contactNumber:"87655444",
                    otherInfo:"123"
                });
                this.branchList.push({
                    id:2,
                    name:"Branch 2",
                    code:"BPL-2",
                    contactNumber:"87655444",
                    otherInfo:"123"
                });
                this.branchList.push({
                    id:3,
                    name:"Branch 3",
                    code:"BPL-3",
                    contactNumber:"87655444",
                    otherInfo:"123"
                });
                this.branchList.push({
                    id:3,
                    name:"Branch 4",
                    code:"BPL-4",
                    contactNumber:"87655444",
                    otherInfo:"123"
                });
                this.branchList.push({
                    id:3,
                    name:"Branch 5",
                    code:"BPL-5",
                    contactNumber:"87655444",
                    otherInfo:"123"
                });
                this.branchList.push({
                    id:3,
                    name:"Branch 6",
                    code:"BPL-6",
                    contactNumber:"87655444",
                    otherInfo:"123"
                });
                */

        if (this.branchList != null && this.branchList.length > 0) {
            return of(this.branchList)
        }
        else {
            let url = `${this.baseService.appInfo.apiUrl}/${BRANCH_SERVICE_URL.ACTION_GET_CUSTOMER_BRANCH}`;
            return this.http.post<ResponseModel<CustomerBranchModel[]>>(url, input).pipe(
                map((data: ResponseModel<CustomerBranchModel[]>) => {
                    if (data != null && data.responseData != null) {
                        this.branchList = data.responseData;
                        this.branchList.forEach(item => {
                            item.addressInfo = null;
                            try {
                                item.addressInfo = JSON.parse(item.address);
                            }
                            catch (ex) { }
                            try {
                                let contact: string[] = JSON.parse(item.contactNumber);
                                if (contact != null && contact.length > 0) {
                                    item.primaryContactNumber = contact[0];
                                }
                            }
                            catch (ex) { }
                        })
                    }
                    return this.branchList;
                })
            );

        }
    }
    public makeInActiveBranch(input: RequestModel<CustomerBranchModel>): Observable<ResponseModel<ResultModel>> {

        let url = `${this.baseService.appInfo.apiUrl}/${BRANCH_SERVICE_URL.ACTION_MAKE_INACTIVE_CUSTOMER_BRANCH}`;
        return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
            this.branchList = [];
        }));

    }

    public getBranchInfo(id: number): Observable<CustomerBranchModel> {

        let branch: CustomerBranchModel = new CustomerBranchModel();
        let searchInput = this.baseService.getSearchRequestModel(branch);
        searchInput.pageNumber = 1;
        searchInput.pageSize = 100;

        return this.getBranchList(searchInput).pipe(
            map((list: CustomerBranchModel[]) => {
                if (list.length > 0) {
                    return list.find(x => x.id == id);
                }
                else {
                    return null;
                }
            }
            )
        );

        /* let url = `${this.baseService.appInfo.apiUrl}/${BRANCH_SERVICE_URL.ACTION_MAKE_INACTIVE_CUSTOMER_BRANCH}`;
         return this.http.post<ResponseModel<ResultModel>>(url, input).pipe(tap(x => {
             this.branchList = [];
         }));
 */
    }



}
