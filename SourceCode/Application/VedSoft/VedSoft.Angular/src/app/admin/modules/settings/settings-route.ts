import { AdminSettingsIndexComponent,CourseSettingsComponent, OrganizationSettingsComponent, SubjectSettingsComponent, StandardsSettingsComponent } from "./components/index"
import { Routes } from '@angular/router';
export const ADMIN_SETTINGS_ROUTES: Routes = [
    { 
        path: '', component: AdminSettingsIndexComponent, children: [
      
            {
              path: 'org', component: OrganizationSettingsComponent
            },
            {
              path: 'subject', component: SubjectSettingsComponent
            },
            {
                path: 'course', component: CourseSettingsComponent
              },
              {
                path: 'standards', component: StandardsSettingsComponent
              },
              {
                path: 'topics', component: StandardsSettingsComponent
              },
              {
                path: 'streams', component: StandardsSettingsComponent
              },
              
            
          ]
    },
    
];

