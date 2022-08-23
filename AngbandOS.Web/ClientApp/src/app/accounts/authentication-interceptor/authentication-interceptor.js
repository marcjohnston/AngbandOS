"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.AuthenticationInterceptor = void 0;
var core_1 = require("@angular/core");
var AuthenticationInterceptor = /** @class */ (function () {
    function AuthenticationInterceptor(_authenticationService) {
        this._authenticationService = _authenticationService;
    }
    // Checks if there is an access_token available in the authorize service
    // and adds it to the request in case it's targeted at the same origin as the
    // single page application.
    AuthenticationInterceptor.prototype.intercept = function (request, next) {
        if (this._authenticationService.isAuthenticated) {
            var token = this._authenticationService.currentUser.value.jwt;
            if (!!token && this.isSameOriginUrl(request)) {
                request = request.clone({
                    setHeaders: {
                        Authorization: "Bearer " + token
                    }
                });
            }
        }
        return next.handle(request);
    };
    AuthenticationInterceptor.prototype.isSameOriginUrl = function (req) {
        // It's an absolute url with the same origin.
        if (req.url.startsWith(window.location.origin + "/")) {
            return true;
        }
        // It's a protocol relative url with the same origin.
        // For example: //www.example.com/api/Products
        if (req.url.startsWith("//" + window.location.host + "/")) {
            return true;
        }
        // It's a relative url like /api/Products
        if (/^\/[^\/].*/.test(req.url)) {
            return true;
        }
        // It's an absolute or protocol relative url that
        // doesn't have the same origin.
        return false;
    };
    AuthenticationInterceptor = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], AuthenticationInterceptor);
    return AuthenticationInterceptor;
}());
exports.AuthenticationInterceptor = AuthenticationInterceptor;
//# sourceMappingURL=authentication-interceptor.js.map