"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var unauthorized_interceptor_service_1 = require("./unauthorized-interceptor.service");
describe('UnauthorizedInterceptorService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(unauthorized_interceptor_service_1.UnauthorizedInterceptorService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=unauthorized-interceptor.service.spec.js.map