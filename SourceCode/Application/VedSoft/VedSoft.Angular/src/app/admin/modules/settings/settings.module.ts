import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../../../core/guards/index";
import { ADMIN_SETTINGS_ROUTES } from "./settings-route"
import { AdminSettingsIndexComponent,OrganizationSettingsComponent,SubjectSettingsComponent, CourseSettingsComponent, StandardsSettingsComponent } from "./components/index"




@NgModule({
    declarations: [
        AdminSettingsIndexComponent,
        OrganizationSettingsComponent,
        SubjectSettingsComponent,
        CourseSettingsComponent,
        StandardsSettingsComponent
    ],
    imports: [
        RouterModule.forChild(ADMIN_SETTINGS_ROUTES)
    ],
    providers: [
    ],
    exports: [AdminSettingsIndexComponent, RouterModule]

})
export class AdminSettingsModule {
    constructor() {
        console.log("AdminSettingsModule");
    }
}
