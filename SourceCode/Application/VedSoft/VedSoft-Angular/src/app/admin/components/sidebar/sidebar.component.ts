import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services';


@Component({
    templateUrl: 'sidebar.component.html',
    selector:'ved-admin-sidebar'
})

export class AdminSidebarComponent implements OnInit {
    
    constructor(private authService: AuthenticationService
      ) {
      }
    ngOnInit() {
    }
    
    logout(){
this.authService.logout().subscribe(x=>{

});
    }
  }