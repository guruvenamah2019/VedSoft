
import { Injectable, Inject } from "@angular/core";
import { Subject, throwError, of, Observable } from 'rxjs';
import { ApplicationModel, ClientBrowserModel } from '../models/shared-model';
import { HttpErrorResponse, HttpClient } from "@angular/common/http";
import { tap, catchError, mapTo, map } from 'rxjs/operators';
import { DeviceDetectorService } from 'ngx-device-detector';

@Injectable({ providedIn: 'root' })
export class BrowserInfoService {
    public clinetInfo: ClientBrowserModel = new ClientBrowserModel();
    constructor(private http: HttpClient, private deviceService: DeviceDetectorService) {

    }

    private getClinetBrowser() {
        this.clinetInfo.DeviceInfo = this.deviceService.getDeviceInfo();
        this.clinetInfo.isMobile = this.deviceService.isMobile();
        this.clinetInfo.isTablet = this.deviceService.isTablet();
        this.clinetInfo.isDesktopDevice = this.deviceService.isDesktop();
    }

    public getClinetIdAddress(): Observable<ClientBrowserModel> {
        this.getClinetBrowser();

        return this.http.get("https://api.ipify.org/?format=json").pipe(
            map(x => {
                if (x != null && x.hasOwnProperty("ip")) {
                    this.clinetInfo.IPAddress = x["ip"];
                }
                return this.clinetInfo;
            }),
            catchError(error => {
                console.log(JSON.stringify(error.error));
                return of(this.clinetInfo);
            }));

    }

}
