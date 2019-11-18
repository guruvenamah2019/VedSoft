import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerGuard } from './core/guards/customer.guard';
import { Error404Component, Error500Component, Error401Component } from './shared/components';

const ROOT_ROUTES: Routes = [
  {
      path: 'public',
      loadChildren: () => import('./public/public.module').then(m => m.PublicModule),
      canActivate: [CustomerGuard]
  },
  {
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
    canActivate: [CustomerGuard]
},
{
  path: 'profile',
  loadChildren: () => import('./profile/profile.module').then(m => m.ProfileModule),
  canActivate: [CustomerGuard]
},
{ 
  path: "401", component: Error401Component,
},
  
 { 
    path: "404", component: Error404Component,
},
{ 
    path: "500", component: Error500Component,
},
  {
      path: '**',
      redirectTo: '404',
      pathMatch: 'full',
  },
  {
    path: 'invalid',
    redirectTo: '404',
},

];

@NgModule({
  imports: [RouterModule.forRoot(ROOT_ROUTES,  { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
