import { NgModule,  } from '@angular/core';
import { LoginComponent,PublicIndexComponent,PublicNavigationComponent,PublicAboutComponent,PublicContactComponent,PublicHomeComponent,PublicServicesComponent } from './components/index';
import { RouterModule } from '@angular/router';
import { AuthGuard } from "../core/guards/auth.guard";
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PUBLIC_ROUTES } from "./public-route"



@NgModule({
    declarations: [
        LoginComponent,
        PublicIndexComponent,
        PublicNavigationComponent,
        PublicAboutComponent,PublicContactComponent,PublicHomeComponent,PublicServicesComponent
    ],
  imports: [
    ReactiveFormsModule,
    CommonModule,
        RouterModule.forChild([
            // { path: 'requisitioning', redirectTo: "requisitioning/dashboard", pathMatch: "full" },
             { path: '', redirectTo: "login" },
          { path: '', component: PublicIndexComponent, children: PUBLIC_ROUTES, canActivate: [AuthGuard] }
         ])
    ],
    providers: [
    ],
    exports: [PublicIndexComponent]

})
export class PublicModule {
    constructor() {
        console.log("PublicModule");
    }
}
