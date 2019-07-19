
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { TranslateService } from '@ngx-translate/core';

@Component({
    templateUrl: 'nav.component.html',
    selector:'ved-public-nav'
})


export class PublicNavigationComponent  {
   
    constructor(public translate: TranslateService) {
        console.log("PublicNavigationComponent")
    }
    userLanguage(lan:string){
        this.translate.use(lan);
    }
   

}