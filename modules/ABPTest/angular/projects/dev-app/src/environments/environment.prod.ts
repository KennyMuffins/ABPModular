import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'IssueManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44333',
    redirectUri: baseUrl,
    clientId: 'IssueManagement_App',
    responseType: 'code',
    scope: 'offline_access IssueManagement',
  },
  apis: {
    default: {
      url: 'https://localhost:44333',
      rootNamespace: 'Acme.IssueManagement',
    },
    IssueManagement: {
      url: 'https://localhost:44386',
      rootNamespace: 'Acme.IssueManagement',
    },
  },
} as Environment;
