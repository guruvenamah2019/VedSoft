import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../../../core/guards/index";
import { STUDENT_ROUTES } from "./student-route"
import { SharedModule } from "../../../shared/shared.module"
import { StudentIndexComponent, StudentComponent, StudentListComponent, StudentAcademicComponent, StudentAdmissionComponent, StudentAttendanceComponent, StudentBatchComponent, StudentDocumentsComponent, StudentEnquiryComponent, StudentLeavesComponent, StudentLoginComponent, StudentPerformanceComponent, StudentProfileComponent, StudentPunchesComponent,StudentAssignmentsComponent, NewStudentComponent } from './components';

@NgModule({
    declarations: [
        StudentIndexComponent,
        StudentComponent,
        StudentListComponent,
        StudentAcademicComponent,
        StudentAdmissionComponent,
        StudentAttendanceComponent,
        StudentBatchComponent,
        StudentDocumentsComponent,
        StudentEnquiryComponent,
        StudentLeavesComponent,
        StudentLoginComponent,
        StudentPerformanceComponent,
        StudentProfileComponent,
        StudentPunchesComponent,
        StudentAssignmentsComponent,
        NewStudentComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild(STUDENT_ROUTES)
    ],
    entryComponents: [
    ],
    providers: [
    ],
    exports: [StudentIndexComponent,StudentComponent,StudentListComponent]

})
export class StudentModule {
    constructor() {
        console.log("BranchModule");
    }
}
