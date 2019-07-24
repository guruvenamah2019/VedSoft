import { NgModule,  } from '@angular/core';
import { ProfileIndexComponent,ChangePasswordComponent, ProfileComponent } from './components/index';
import { RouterModule } from '@angular/router';
import { AuthGuard } from "../core/guards/auth.guard";
import { SharedModule } from "../shared/shared.module"
import { PROFILE_ROUTES } from "./profile-route"
import { EncryptionModule } from '../encryption/encryption.module';



@NgModule({
    declarations: [
        ProfileIndexComponent,ChangePasswordComponent, ProfileComponent
    ],
  imports: [
    SharedModule,
    EncryptionModule,
    RouterModule.forChild(PROFILE_ROUTES)
    ],
    providers: [
    ],
    exports: [ProfileIndexComponent]

})
export class ProfileModule {
    constructor() {
        console.log("ProfileModule");
    }
}
