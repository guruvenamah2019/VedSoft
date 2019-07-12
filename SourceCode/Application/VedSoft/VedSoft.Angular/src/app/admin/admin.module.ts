import { NgModule } from '@angular/core';
import { AdminIndexComponent,DashboardComponent } from './components/index';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../core/guards/index";
import { PUBLIC_ROUTES } from "./admin-route"



@NgModule({
    declarations: [
        AdminIndexComponent,
        DashboardComponent,
    ],
    imports: [
        RouterModule.forChild([
            // { path: 'requisitioning', redirectTo: "requisitioning/dashboard", pathMatch: "full" },
             { path: '', redirectTo: "dashboard" },
             { path: '', component: AdminIndexComponent, children: PUBLIC_ROUTES, canActivate: [AdminGuard] }
         ])
    ],
    providers: [
    ],
    exports: [AdminIndexComponent]

})
export class AdminModule {
    constructor() {
        console.log("AdminModule");
    }
}
