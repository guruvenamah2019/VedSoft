import { NgModule } from '@angular/core';
import { AdminDashboardComponent, AdminIndexComponent, AdminFollowupsComponent, AdminActivitiesComponent } from './components/index';

import { Routes, RouterModule } from '@angular/router';
import { AdminGuard } from '../core/guards/admin.guard';
export const ADMIN_ROUTES: Routes = [
    {

        path: "", component: AdminIndexComponent, children: [
            {
                path: "dashboard", component: AdminDashboardComponent
            },
            {
                path: "followups", component: AdminFollowupsComponent
            },
            {
                path: "activities", component: AdminActivitiesComponent
            },
            

            { path: 'settings', loadChildren: () => import('./modules/settings/settings.module').then(m => m.AdminSettingsModule) },
            {
                path: '', redirectTo: 'dashboard', pathMatch: 'full'
            },

            { path: 'branchs', loadChildren: () => import('./modules/branch/branch.module').then(m => m.BranchModule) },
            { path: 'reports', loadChildren: () => import('./modules/reports/reports.module').then(m => m.ReportsModule) },
            
        ],

        canActivate: [AdminGuard]


    },

];

