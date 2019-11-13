import { Routes } from '@angular/router';
import { BranchIndexComponent, BranchListComponent} from './components';
import { BranchGuard } from 'src/app/core/guards/branch-guard';
export const BRANCH_ROUTES: Routes = [
  { path: '', component:BranchListComponent },
    { 
        path: ':branchId',  component: BranchIndexComponent,  loadChildren: () => import('../student/student.module').then(m => m.StudentModule) },


          
    
    
];

