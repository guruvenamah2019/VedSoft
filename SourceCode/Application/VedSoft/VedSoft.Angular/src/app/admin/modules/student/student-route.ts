import { Routes } from '@angular/router';
import { StudentIndexComponent, StudentListComponent,NewStudentComponent, StudentComponent, StudentProfileComponent, StudentEnquiryComponent, StudentAdmissionComponent, StudentAssignmentsComponent, StudentDocumentsComponent, StudentLoginComponent, StudentLeavesComponent, StudentAcademicComponent, StudentBatchComponent, StudentPunchesComponent, StudentAttendanceComponent } from './components';
import { BranchGuard } from 'src/app/core/guards';
export const STUDENT_ROUTES: Routes = [
    { 
        path: '',redirectTo:'students'
      },
      { 
        path: 'students',  component: StudentListComponent
      },
        

        { path: 'students/new', component: NewStudentComponent},
           
            { path: 'students/:studentId', component: StudentComponent,children: [
               
      
                {
                  path: 'profile', component: StudentProfileComponent
                },
                {
                  path: 'performance', component: StudentProfileComponent
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

