import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../../../core/guards/index";
import { BRANCH_ROUTES } from "./branch-route"
import { SharedModule } from "../../../shared/shared.module"
import { BranchIndexComponent, BranchListComponent,AddBranchComponent } from './components';

@NgModule({
    declarations: [
        BranchIndexComponent,
        BranchListComponent,
        AddBranchComponent
       
    ],
    imports: [
        SharedModule,
        RouterModule.forChild(BRANCH_ROUTES)
    ],
    entryComponents: [
        AddBranchComponent
    ],
    providers: [
    ],
    exports: [BranchIndexComponent,BranchListComponent]

})
export class BranchModule {
    constructor() {
        console.log("BranchModule");
    }
}
