import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../../../core/guards/index";
import { ADMIN_SETTINGS_ROUTES } from "./settings-route"
import { AdminSettingsIndexComponent,OrganizationSettingsComponent,SubjectSettingsComponent } from "./components/index"




@NgModule({
    declarations: [
        AdminSettingsIndexComponent,
        OrganizationSettingsComponent,
        SubjectSettingsComponent
    ],
    imports: [
        RouterModule.forChild([
            // { path: 'requisitioning', redirectTo: "requisitioning/dashboard", pathMatch: "full" },
           //  { path: '', component: AdminSettingsIndexComponent, children: ADMIN_SETTINGS_ROUTES, canActivate: [AdminGuard] }
         ])
    ],
    providers: [
    ],
    exports: [AdminSettingsIndexComponent]

})
export class AdminSettingsModule {
    constructor() {
        console.log("AdminSettingsModule");
    }
}
