import { NgModule } from '@angular/core';
import { LoginComponent,PublicIndexComponent,PublicNavigationComponent,PublicAboutComponent,PublicContactComponent,PublicHomeComponent,PublicServicesComponent } from './components/index';

import { Routes, RouterModule } from '@angular/router';
export const PUBLIC_ROUTES: Routes = [
    { 
        path: "login", component: LoginComponent,
    },
    { 
        path: "home", component: PublicHomeComponent,
    },
    { 
        path: "about", component: PublicAboutComponent,
    },
    { 
        path: "contact", component: PublicContactComponent,
    },
    { 
        path: "services", component: PublicServicesComponent,
    },
];

