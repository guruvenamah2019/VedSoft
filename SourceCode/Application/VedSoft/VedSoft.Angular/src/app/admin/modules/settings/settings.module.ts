import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../../../core/guards/index";
import { ADMIN_SETTINGS_ROUTES } from "./settings-route"
import { AdminSettingsIndexComponent,OrganizationSettingsComponent,SubjectSettingsComponent, 
    CourseSettingsComponent, StandardsSettingsComponent, AddStandardComponent } from "./components/index"
import { ModalModule, BsModalService } from 'ngx-bootstrap/modal';




@NgModule({
    declarations: [
        AdminSettingsIndexComponent,
        OrganizationSettingsComponent,
        SubjectSettingsComponent,
        CourseSettingsComponent,
        StandardsSettingsComponent,
        AddStandardComponent
    ],
    imports: [
        ModalModule.forRoot(),
        RouterModule.forChild(ADMIN_SETTINGS_ROUTES)
    ],
    entryComponents: [
        AddStandardComponent
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
