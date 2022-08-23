"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.UnauthorizedInterceptorService = void 0;
var core_1 = require("@angular/core");
var rxjs_1 = require("rxjs");
var operators_1 = require("rxjs/operators");
var UnauthorizedInterceptorService = /** @class */ (function () {
    function UnauthorizedInterceptorService(_snackBarService, _router) {
        this._snackBarService = _snackBarService;
        this._router = _router;
    }
    UnauthorizedInterceptorService.prototype.intercept = function (request, next) {
        var _this = this;
        return next.handle(request).pipe(operators_1.catchError(function (error) {
            //401 UNAUTHORIZED
            var err = "" + error.message;
            if (error && error.status === 401) {
                _this._snackBarService.show("ERROR 401 UNAUTHORIZED.  " + err);
                _this._router.navigateByUrl("/login?url=" + encodeURIComponent(request.url));
            }
            _this._snackBarService.show(err);
            return rxjs_1.throwError(error);
        }));
    };
    UnauthorizedInterceptorService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], UnauthorizedInterceptorService);
    return UnauthorizedInterceptorService;
}());
exports.UnauthorizedInterceptorService = UnauthorizedInterceptorService;
//# sourceMappingURL=unauthorized-interceptor.service.js.map