import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../../../core/guards/index";
import { REPORTS_ROUTES } from "./reports-route"
import { SharedModule } from "../../../shared/shared.module"
import { ReportsAdmissionComponent, ReportsEnquiryComponent, ReportsExpensesComponent, ReportsFeesComponent, ReportsIndexComponent } from './components';

@NgModule({
    declarations: [
        ReportsAdmissionComponent,
        ReportsEnquiryComponent,
        ReportsExpensesComponent,
        ReportsFeesComponent,
        ReportsIndexComponent,
        
    ],
    imports: [
        SharedModule,
        RouterModule.forChild(REPORTS_ROUTES)
    ],
    entryComponents: [
    ],
    providers: [
    ],
    exports: [ReportsIndexComponent]

})
export class ReportsModule {
    constructor() {
        console.log("BranchModule");
    }
}
