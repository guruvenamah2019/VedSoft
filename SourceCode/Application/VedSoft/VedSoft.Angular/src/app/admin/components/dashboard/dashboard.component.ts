
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { AuthenticationService } from 'src/app/core/services';

@Component({
    templateUrl: 'dashboard.component.html',
})


export class AdminDashboardComponent  {
   
    constructor(private auth: AuthenticationService) {
        console.log("SidebarComponent");

    }
    ngOnInit() {
        
    }


    get userName():string{

        return this.auth.loggedUser.firstName ; 


    }
   

   




}