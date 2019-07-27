import { NgModule } from '@angular/core';
import { ProfileIndexComponent,ChangePasswordComponent, ProfileComponent } from './components/index';
import { Routes, RouterModule } from '@angular/router';
import { AdminGuard, AuthGuard } from '../core/guards';

export const PROFILE_ROUTES: Routes = [

    { 
        path: "", component: ProfileIndexComponent, children: [
            {
                path: "me", component: ProfileComponent,
            },
            {
                path: "password", component: ChangePasswordComponent,
            },
            {
                path: '', redirectTo: 'me', pathMatch: 'full'
            },
        ],
        canActivate: [AuthGuard]

    }
];

