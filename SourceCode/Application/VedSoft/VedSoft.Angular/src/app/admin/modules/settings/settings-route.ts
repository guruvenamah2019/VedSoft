import { AdminSettingsIndexComponent,OrganizationSettingsComponent, SubjectSettingsComponent } from "./components/index"
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
            
            
          ]
    },
    
];

