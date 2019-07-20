
export class ClientBrowserModel{
    IPAddress?:string;
    DeviceInfo?:any;
    isMobile?:boolean;
    isDesktopDevice?:boolean;
    isTablet?:boolean;
    constructor(){
        this.IPAddress="";
        this.DeviceInfo={};
    }
}