import { NgModule } from '@angular/core';
import { DynamicLayoutComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { SystemManagementComponent } from './components/system-management.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: DynamicLayoutComponent,
    children: [
      {
        path: '',
        component: SystemManagementComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SystemManagementRoutingModule {}
