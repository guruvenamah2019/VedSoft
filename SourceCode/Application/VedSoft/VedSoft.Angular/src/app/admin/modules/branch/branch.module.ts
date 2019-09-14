import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../../../core/guards/index";
import { BRANCH_ROUTES } from "./branch-route"
import { SharedModule } from "../../../shared/shared.module"
import { BranchIndexComponent, StudentComponent, StudentListComponent } from './components';

@NgModule({
    declarations: [
        BranchIndexComponent,
        //StudentComponent,
        //StudentListComponent
    ],
    imports: [
        SharedModule,
        RouterModule.forChild(BRANCH_ROUTES)
    ],
    entryComponents: [
    ],
    providers: [
    ],
    exports: [BranchIndexComponent]

})
export class BranchModule {
    constructor() {
        console.log("BranchModule");
    }
}
