import { NgModule,  } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ModalModule, BsModalService,BsDropdownModule  } from 'ngx-bootstrap';




@NgModule({
    declarations: [
        
    ],
  imports: [
    ReactiveFormsModule,
    CommonModule,
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    ],
    exports:[
        ReactiveFormsModule,
        CommonModule,
        ModalModule,
        BsDropdownModule

    ],
    providers: [
    ],

})
export class SharedModule {
    constructor() {
        console.log("SharedModule");
    }
}
