import { NgModule } from '@angular/core';
import { AdminIndexComponent,AdminFooterComponent,AdminHeaderComponent,AdminSidebarComponent,AdminDashboardComponent } from './components/index';
import { RouterModule } from '@angular/router';
import { AuthGuard, AdminGuard } from "../core/guards/index";
import {AdminSettingsModule} from "./modules/settings/settings.module";
import { ADMIN_ROUTES } from "./admin-route";
import { SharedModule } from "../shared/shared.module"



@NgModule({
    declarations: [
        AdminIndexComponent,
        AdminFooterComponent,AdminHeaderComponent,AdminSidebarComponent, AdminDashboardComponent
    ],
    imports: [
        SharedModule,
        AdminSettingsModule,
        RouterModule.forChild(ADMIN_ROUTES)
    ],
    providers: [
    ],
    exports: [AdminIndexComponent,RouterModule],
    bootstrap: [AdminIndexComponent]

})
export class AdminModule {
    constructor() {
        console.log("AdminModule");
    }
}
