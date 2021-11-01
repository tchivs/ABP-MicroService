import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { SystemManagementComponent } from './components/system-management.component';
import { SystemManagementRoutingModule } from './system-management-routing.module';

@NgModule({
  declarations: [SystemManagementComponent],
  imports: [CoreModule, ThemeSharedModule, SystemManagementRoutingModule],
  exports: [SystemManagementComponent],
})
export class SystemManagementModule {
  static forChild(): ModuleWithProviders<SystemManagementModule> {
    return {
      ngModule: SystemManagementModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<SystemManagementModule> {
    return new LazyModuleFactory(SystemManagementModule.forChild());
  }
}
