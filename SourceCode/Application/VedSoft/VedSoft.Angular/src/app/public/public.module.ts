import { NgModule,  } from '@angular/core';
import { LoginComponent,PublicIndexComponent,PublicNavigationComponent,PublicAboutComponent,PublicContactComponent,PublicHomeComponent,PublicServicesComponent } from './components/index';
import { RouterModule } from '@angular/router';
import { AuthGuard } from "../core/guards/auth.guard";
import { SharedModule } from "../shared/shared.module"
import { PUBLIC_ROUTES } from "./public-route"
import { EncryptionModule } from '../encryption/encryption.module';
import { AdminGuard } from '../core/guards';



@NgModule({
    declarations: [
        LoginComponent,
        PublicIndexComponent,
        PublicNavigationComponent,
        PublicAboutComponent,PublicContactComponent,PublicHomeComponent,PublicServicesComponent
    ],
  imports: [
    SharedModule,
    EncryptionModule,
        RouterModule.forChild([
            // { path: 'requisitioning', redirectTo: "requisitioning/dashboard", pathMatch: "full" },
             { path: '', redirectTo: "login" },
          { path: '', component: PublicIndexComponent, children: PUBLIC_ROUTES }
         ])
    ],
    providers: [
    ],
    exports: [PublicIndexComponent]

})
export class PublicModule {
    constructor() {
        console.log("PublicModule");
    }
}
