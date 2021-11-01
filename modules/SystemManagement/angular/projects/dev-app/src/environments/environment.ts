import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'SystemManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44324',
    redirectUri: baseUrl,
    clientId: 'SystemManagement_App',
    responseType: 'code',
    scope: 'offline_access SystemManagement role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44324',
      rootNamespace: 'SystemManagement',
    },
    SystemManagement: {
      url: 'https://localhost:44326',
      rootNamespace: 'SystemManagement',
    },
  },
} as Environment;
