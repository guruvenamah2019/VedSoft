import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const ROOT_ROUTES: Routes = [
  {
      path: 'public',
      loadChildren: () => import('./public/public.module').then(m => m.PublicModule),
  },
  {
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
},
{
  path: 'profile',
  loadChildren: () => import('./profile/profile.module').then(m => m.ProfileModule),
},
   
  {
      path: '404',
      redirectTo: 'public',
  },
  {
      path: '**',
      redirectTo: 'public',
      pathMatch: 'full',
  },

];

@NgModule({
  imports: [RouterModule.forRoot(ROOT_ROUTES)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
