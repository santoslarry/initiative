import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestComponent } from './components/test/test.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MsalGuard } from '@azure/msal-angular';

const routes: Routes = [
  { path: '', component: TestComponent, canActivate:[MsalGuard] },
  { path: 'dashboard', component: DashboardComponent, canActivate:[MsalGuard] },
  { path: 'test', component: TestComponent, canActivate:[MsalGuard] },
  { path: '**', component: TestComponent, canActivate:[MsalGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
