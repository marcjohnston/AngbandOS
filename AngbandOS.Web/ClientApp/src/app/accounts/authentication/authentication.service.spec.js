"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var authentication_service_1 = require("./authentication.service");
describe('AuthenticationService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(authentication_service_1.AuthenticationService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=authentication.service.spec.js.map