import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../../../core/guards/index";
import { ADMIN_DASHBOARD_ROUTES } from "./dashboard-route"
import {AdminDashboardComponent,AdminDashboardIndexComponent} from "./components/index"



@NgModule({
    declarations: [
        AdminDashboardComponent,
        AdminDashboardIndexComponent
    ],
    imports: [
        RouterModule.forChild([
            // { path: 'requisitioning', redirectTo: "requisitioning/dashboard", pathMatch: "full" },
             { path: '', redirectTo: "dashboard" },
             { path: '', component: AdminDashboardIndexComponent, children: ADMIN_DASHBOARD_ROUTES, canActivate: [AdminGuard] }
         ])
    ],
    providers: [
    ],
    exports: [AdminDashboardIndexComponent]

})
export class AdminDashboardModule {
    constructor() {
        console.log("AdminDashboardModule");
    }
}
