import { NgModule } from '@angular/core';
import { AdminIndexComponent,DashboardComponent } from './components/index';

import { Routes, RouterModule } from '@angular/router';
export const PUBLIC_ROUTES: Routes = [
    { 
        path: "dashboard", component: DashboardComponent,
    },
    
];

