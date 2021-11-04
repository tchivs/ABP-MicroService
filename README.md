# Abp-MicroServer

## 项目简介

基于Abp
vNext微服务架构创建的项目，因为是采用Abp模块化开发，所以可以自由组合使用。前后端分离了，但没完全分，支持分开部署。因为本人前端框架只会vue，但是被各种前端库和webpack编译劝退。于是选择使用Blazor一把梭，还不用另外创建接口实体类与服务。

后台管理使用[BootstrapBlazor](https://github.com/LongbowEnterprise/BootstrapBlazor) 搭建页面，同时支持Server与WebAssembly模式

## 简单说明
- AuthServer-授权服务:https://localhost:3000
- IdentityService-用户管理服务：https://localhost:3001
- TenantService-租户管理服务：https://localhost:3002
- ~~BasicService-基础服务：https://localhost:3003~~ 已删除
- InternalGateway-内部网关:https://localhost:3004
- BackendAdminAppGateway-后台管理网关：https://localhost:3005
- SystemService-系统后台管理服务：https://localhost:3006
- BackendAdminBlazorServer-后台管理页面（ssr）：https://localhost:3009
- BackendAdminBlazorWebassembly-后台管理页面（wasm）：https://localhost:3010

## 系统功能

- [x] 用户管理
- [x] 角色管理
- [ ] 租户管理（页面还没做）
- [ ] IdentityServer4(接口做好了)
    - [ ] 客户端管理
    - [ ] ApiScope管理
    - [ ] Api资源管理
    - [ ] Identity资源管理
- [ ] 后台任务(hangfire)
- [ ] SinglaR 消息通知
- [ ] 数据字典管理
- [ ] 集成事件(dotnetcore.cap)
- [ ] 单元测试
- [ ] 组织机构
- [ ] WPF客户端，使用reactive-ui或者prism框架搭配abp使用，授权一条龙
- [ ] 服务发现，目前是手动在网关中配置
## 使用
## 致谢

在编码过程中参考了以下项目或文档：

- [官方项目与说明](https://docs.abp.io/zh-Hans/abp/latest/Samples/Microservice-Demo)
- [abp-vnext-pro](https://github.com/WangJunZzz/abp-vnext-pro)
- [ABP-MicroService](https://github.com/WilliamXu96/ABP-MicroService)