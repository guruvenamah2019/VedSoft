import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../../../core/guards/index";
import { ADMIN_SETTINGS_ROUTES } from "./settings-route"
import { AdminSettingsIndexComponent,OrganizationSettingsComponent,SubjectSettingsComponent, 
    CourseSettingsComponent, StandardsSettingsComponent, AddStandardComponent, BranchSettingComponent, AddBranchComponent, UserRoleSettingComponent, AddUserRoleComponent, BankSettingsComponent, AddBankComponent, InstituteSettingsComponent, AddInstituteComponent } from "./components/index"
import { SharedModule } from "../../../shared/shared.module"





@NgModule({
    declarations: [
        AdminSettingsIndexComponent,
        OrganizationSettingsComponent,
        SubjectSettingsComponent,
        CourseSettingsComponent,
        StandardsSettingsComponent,
        AddStandardComponent,
        BranchSettingComponent,
        AddBranchComponent,
        UserRoleSettingComponent,
        AddUserRoleComponent,
        BankSettingsComponent,
        AddBankComponent,
        InstituteSettingsComponent,
        AddInstituteComponent
        
    ],
    imports: [
        SharedModule,
        RouterModule.forChild(ADMIN_SETTINGS_ROUTES)
    ],
    entryComponents: [
        AddStandardComponent,
        AddBranchComponent,
        AddUserRoleComponent,
        AddBankComponent,
        AddInstituteComponent
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
