import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../../../core/guards/index";
import { ADMIN_SETTINGS_ROUTES } from "./settings-route"
import { AdminSettingsIndexComponent,OrganizationSettingsComponent,SubjectSettingsComponent, 
    CourseSettingsComponent, StandardsSettingsComponent, AddStandardComponent } from "./components/index"
import { ModalModule, BsModalService,BsDropdownModule  } from 'ngx-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';






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
        CommonModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        BsDropdownModule.forRoot(),
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
