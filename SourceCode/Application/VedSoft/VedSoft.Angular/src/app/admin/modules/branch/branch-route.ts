import { Routes } from '@angular/router';
import { BranchIndexComponent, StudentListComponent, StudentComponent } from './components';
export const BRANCH_ROUTES: Routes = [
    { 
        path: '', component: BranchIndexComponent, children: [
          {
            path: '', redirectTo:"students"
          },
            {
              path: 'students', component: StudentListComponent
            },
            { path: 'student/:id', component: StudentComponent}
            
          ]
    },
    
];

