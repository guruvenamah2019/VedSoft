import { Routes } from '@angular/router';
import { BranchGuard } from 'src/app/core/guards';
import { ReportsAdmissionComponent, ReportsEnquiryComponent, ReportsExpensesComponent, ReportsFeesComponent, ReportsIndexComponent } from './components';

export const REPORTS_ROUTES: Routes = [
    { 
        path: 'admissions', component:ReportsAdmissionComponent
      },
      { 
        path: 'enquiry', component:ReportsEnquiryComponent
      },
      { 
        path: 'expenses', component:ReportsExpensesComponent
      },
      { 
        path: 'fees', component:ReportsFeesComponent
      },
      
];

