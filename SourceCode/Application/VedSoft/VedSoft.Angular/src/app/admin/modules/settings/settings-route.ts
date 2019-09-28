import { AdminSettingsIndexComponent,CourseSettingsComponent, OrganizationSettingsComponent,  SubjectSettingsComponent, BranchSettingComponent, UserRoleSettingComponent, BankSettingsComponent, InstituteSettingsComponent, AcademicYearSettingsComponent } from "./components/index"
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
                path: 'standards', component: SubjectSettingsComponent,data:{level:1}
              },
              {
                path: 'streams', component: SubjectSettingsComponent,data:{level:2}
              },
              {
                path: 'subject', component: SubjectSettingsComponent, data:{level:3}
              },
              {
                path: 'topics', component: SubjectSettingsComponent,data:{level:4}
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
              {
                path: 'academicyear', component: AcademicYearSettingsComponent
              },
              { path: 'students', loadChildren: () => import('../student/student.module').then(m => m.StudentModule) },
            
          ]
    },
    
];

