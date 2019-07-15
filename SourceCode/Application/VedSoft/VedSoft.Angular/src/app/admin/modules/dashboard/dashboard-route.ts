import { NgModule } from '@angular/core';
import { AdminDashboardIndexComponent,AdminDashboardComponent } from './components/index';

import { Routes, RouterModule } from '@angular/router';
export const ADMIN_DASHBOARD_ROUTES: Routes = [
    { 
        path: "dashboard", component: AdminDashboardComponent,
    },
    
];

