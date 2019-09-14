import { Routes } from '@angular/router';
import { StudentIndexComponent, StudentListComponent, StudentComponent } from './components';
export const STUDENT_ROUTES: Routes = [
    { 
        path: '', component: StudentListComponent},
           
            { path: 'student/:id', component: StudentComponent}
    
];

