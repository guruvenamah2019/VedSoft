
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { Location } from '@angular/common';

@Component({
    templateUrl: '401.component.html',
})


export class Error401Component  {
   
    constructor(private loc: Location ) {
        console.log("LoginComponent")
        
    }
   
    back(){
        this.loc.back();
    }

}