
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { AuthenticationService } from 'src/app/core/services';

@Component({
    templateUrl: 'activities.component.html',
})


export class AdminActivitiesComponent  {
   
    constructor(private auth: AuthenticationService) {
        console.log("SidebarComponent");

    }
    ngOnInit() {
        
    }


    get userName():string{

        return this.auth.loggedUser.firstName ; 


    }
   

   




}