import { Routes } from '@angular/router';
import { BranchIndexComponent, BranchListComponent, BranchBatchComponent, StudentListComponent, BranchCourseComponent } from './components';
export const BRANCH_ROUTES: Routes = [


  {

    path: '', component: BranchListComponent
  },


  { path: 'branchs/:branchId', redirectTo: 'branch/:branchId' },

  {
    path: ':branchId', component: BranchIndexComponent, children: [


      {

        path: '', redirectTo: "students"
      },
      {
        path: 'batches', component: BranchBatchComponent
      },
      {
        path: 'course', component: BranchCourseComponent
      },
      {

        path: 'students', component: StudentListComponent
      },
      { path: 'students/:id', redirectTo: 'student/:id' },


      {

        path: 'student/:studentId', loadChildren: () => import('../student/student.module').then(m => m.StudentModule)
      },

    ]
  },
  /*
    
      { 
  
          path: ':branchId',  component: BranchIndexComponent,  loadChildren: () => import('../student/student.module').then(m => m.StudentModule) },*/


];

