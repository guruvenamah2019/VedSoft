import { NgModule } from '@angular/core';
import { AdminDashboardComponent, AdminIndexComponent } from './components/index';

import { Routes, RouterModule } from '@angular/router';
import { AdminGuard } from '../core/guards/admin.guard';
export const ADMIN_ROUTES: Routes = [
    {

        path: "", component: AdminIndexComponent, children: [
            {
                path: "dashboard", component: AdminDashboardComponent
            },

            { path: 'settings', loadChildren: () => import('./modules/settings/settings.module').then(m => m.AdminSettingsModule) },
            {
                path: '', redirectTo: 'dashboard', pathMatch: 'full'
            },
        ],

        canActivate: [AdminGuard]


    },

];

