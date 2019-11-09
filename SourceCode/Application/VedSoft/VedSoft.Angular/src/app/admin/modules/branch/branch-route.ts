import { Routes } from '@angular/router';
import { BranchIndexComponent, BranchListComponent} from './components';
export const BRANCH_ROUTES: Routes = [
  { path: '', component:BranchListComponent },
    { 
        path: ':id', component: BranchIndexComponent,  loadChildren: () => import('../student/student.module').then(m => m.StudentModule) },


          
    
    
];

