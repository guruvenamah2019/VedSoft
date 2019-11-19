
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { AuthenticationService } from 'src/app/core/services';

@Component({
    templateUrl: 'followups.component.html',
})


export class AdminFollowupsComponent  {
   
    constructor(private auth: AuthenticationService) {
        console.log("SidebarComponent");

    }
    ngOnInit() {
        
    }


    get userName():string{

        return this.auth.loggedUser.firstName ; 


    }
   

   




}