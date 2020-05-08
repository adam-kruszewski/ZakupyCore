import { TestBed } from '@angular/core/testing';

import { LoginTokenInterceptorService } from './login-token-interceptor.service';

describe('LoginTokenInterceptorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LoginTokenInterceptorService = TestBed.get(LoginTokenInterceptorService);
    expect(service).toBeTruthy();
  });
});
