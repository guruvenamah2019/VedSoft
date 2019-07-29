export class RequestModel<T>  {
    requestParameter: T;
    aPIClientId?: number;
    CustomerId?: number;
    RequestTxnID?: string;
    LanguageId?: number;
}

export class SearchRequestModel<T> extends RequestModel<T>  
    {
        pageSize: number;
        pageNumber: number;
    }
