import { AdminSettingsIndexComponent,CourseSettingsComponent, OrganizationSettingsComponent, SubjectSettingsComponent, StandardsSettingsComponent, BranchSettingComponent, UserRoleSettingComponent, BankSettingsComponent, InstituteSettingsComponent } from "./components/index"
import { Routes } from '@angular/router';
export const ADMIN_SETTINGS_ROUTES: Routes = [
    { 
        path: '', component: AdminSettingsIndexComponent, children: [
      
            {
              path: 'org', component: OrganizationSettingsComponent
            },
            {
              path: 'branch', component: BranchSettingComponent
            },
            {
                path: 'course', component: CourseSettingsComponent
              },
              {
                path: 'standards', component: StandardsSettingsComponent,data:{level:1}
              },
              {
                path: 'streams', component: StandardsSettingsComponent,data:{level:2}
              },
              {
                path: 'subject', component: StandardsSettingsComponent, data:{level:3}
              },
              {
                path: 'topics', component: StandardsSettingsComponent,data:{level:4}
              },
              {
                path: 'roles', component: UserRoleSettingComponent,data:{level:4}
              },
              {
                path: 'bank', component: BankSettingsComponent
              },
              {
                path: 'institute', component: InstituteSettingsComponent
              },
            
          ]
    },
    
];

