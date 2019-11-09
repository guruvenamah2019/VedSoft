import { Routes } from '@angular/router';
import { StudentIndexComponent, StudentListComponent, StudentComponent, StudentProfileComponent, StudentEnquiryComponent, StudentAdmissionComponent, StudentAssignmentsComponent, StudentDocumentsComponent, StudentLoginComponent, StudentLeavesComponent, StudentAcademicComponent, StudentBatchComponent, StudentPunchesComponent, StudentAttendanceComponent } from './components';
export const STUDENT_ROUTES: Routes = [
    { 
        path: '', component: StudentListComponent},
           
            { path: ':id', component: StudentComponent,children: [
                {
                    path: '', component: StudentProfileComponent
                  },
      
                {
                  path: 'profile', component: StudentProfileComponent
                },
                {
                  path: 'enquiry', component: StudentEnquiryComponent
                },
                {
                    path: 'admission', component: StudentAdmissionComponent
                  },
                  {
                    path: 'assignments', component: StudentAssignmentsComponent
                  },
                  {
                    path: 'documents', component: StudentDocumentsComponent
                  },
                  {
                    path: 'login', component: StudentLoginComponent 
                  },
                  {
                    path: 'leaves', component: StudentLeavesComponent
                  },
                  {
                    path: 'academic', component: StudentAcademicComponent
                  },
                  {
                    path: 'batch', component: StudentBatchComponent
                  },
                  {
                    path: 'punches', component: StudentPunchesComponent
                  },
                  {
                    path: 'attendance', component: StudentAttendanceComponent
                  },
                 
              ]
        
        }
    
];

