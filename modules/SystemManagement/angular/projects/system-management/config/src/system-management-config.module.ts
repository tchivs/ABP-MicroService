import { ModuleWithProviders, NgModule } from '@angular/core';
import { SYSTEM_MANAGEMENT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class SystemManagementConfigModule {
  static forRoot(): ModuleWithProviders<SystemManagementConfigModule> {
    return {
      ngModule: SystemManagementConfigModule,
      providers: [SYSTEM_MANAGEMENT_ROUTE_PROVIDERS],
    };
  }
}
