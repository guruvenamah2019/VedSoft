
import { Injectable } from '@angular/core'
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { BaseService } from '../services/base.service';
//import { CookieService } from 'ngx-cookie-service';
import { catchError, map, tap, finalize } from 'rxjs/operators';

@Injectable()
export class ResponseInterceptor implements HttpInterceptor {
    constructor(private _app: BaseService) {
    }

    request: HttpRequest<any>;
    /*
    private validateAppVersion(): boolean {
        var appVersion = this._cookies.get(this._app.cookies.applicationVersion);
        if (appVersion != this._app.APPLICATION_VERSION)// both are not match then forcefully refresh the page
        {
            console.log("Cookie Version:" + appVersion + " browser Version:" + this._app.APPLICATION_VERSION);
            window.location.reload(true);
            return false;
        }
        return true;
    }
    private validateAuthCookie(): boolean {
        var userId = this._cookies.get(this._app.cookies.userId);
        console.info("Url:" + this.request.url + " Log count start:" + this._app.requestCount);
        if ((this.request.url.toLowerCase().indexOf("/p2plogin/") == -1 &&  (userId == undefined || userId == null || userId == ""))) {
            window.location.href = this._app.appUrl.apiUrl + "/p2phome/#/login";
            this._cookies.deleteAll();
            return false;
        }
        return true;
    }
    */
    private onError(err: any): Observable<any> {
        console.log(err);
        if (err instanceof HttpResponse) {
            console.log(err.status);
            console.log(err.body);
        }
        console.info("Url:" + this.request.url + " Response error count end:" + this._app.requestCount);
        if ((err.status === 401 || err.status === 403) && (window.location.href.match(/\?/g) || []).length < 2) {
            console.log('The authentication session expires or the user is not authorised. Force refresh of the current page.');
            window.location.href = window.location.href + '?' + new Date().getMilliseconds();
        }

        return of(err);
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.request = req;

        //this.validateAppVersion();  

        //if (!this.validateAuthCookie()) {
        //    return Observable.throw("");
        //}

        this._app.requestCount++;

        return next.handle(req).pipe(

            map(resp => {
                if (resp instanceof HttpResponse) {
                    //console.log('Response is ::');
                    //console.log(resp.body)
                }
                return resp;
            }),
            catchError(this.onError),
            finalize(() => {
                this._app.requestCount--;
                console.info("Url:" + req.url + " response count End:" + this._app.requestCount);
          //      this.validateAppVersion();
            })
        );



    }
}