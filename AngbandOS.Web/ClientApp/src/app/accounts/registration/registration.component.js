"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __spreadArrays = (this && this.__spreadArrays) || function () {
    for (var s = 0, i = 0, il = arguments.length; i < il; i++) s += arguments[i].length;
    for (var r = Array(s), k = 0, i = 0; i < il; i++)
        for (var a = arguments[i], j = 0, jl = a.length; j < jl; j++, k++)
            r[k] = a[j];
    return r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.RegistrationComponent = void 0;
var core_1 = require("@angular/core");
var registration_form_group_1 = require("./registration-form-group");
var RegistrationComponent = /** @class */ (function () {
    function RegistrationComponent(_httpClient, _router, _authenticationService, _snackBarService, _zone) {
        this._httpClient = _httpClient;
        this._router = _router;
        this._authenticationService = _authenticationService;
        this._snackBarService = _snackBarService;
        this._zone = _zone;
        this.formGroup = new registration_form_group_1.RegistrationFormGroup();
        this.messages = [];
    }
    Object.defineProperty(RegistrationComponent.prototype, "isAuthenticated", {
        get: function () {
            return this._authenticationService.isAuthenticated;
        },
        enumerable: false,
        configurable: true
    });
    RegistrationComponent.prototype.onRegisterClick = function () {
        var _this = this;
        if (this.formGroup.valid) {
            this.messages = ["Creating account ..."];
            var postUser = {
                username: this.formGroup.username.value,
                emailAddress: this.formGroup.emailAddress.value,
                password: this.formGroup.password.value
            };
            // Create the user account.
            this._httpClient.post("/api/users", postUser).toPromise().then(function () {
                // Log the user in automatically.
                _this._authenticationService.login(_this.formGroup.emailAddress.value, _this.formGroup.password.value).then(function () {
                    // Navigate to the profile page to send the confirmation email.
                    _this._zone.run(function () { _this._router.navigate(["/profile"], { queryParams: { confirm: "true" } }); });
                }, function (_errorResponse) {
                    _this.messages = __spreadArrays(_errorResponse.error);
                });
            }, function (_errorResponse) {
                _this._snackBarService.showError(_errorResponse);
                _this.messages = __spreadArrays(_errorResponse.error);
            });
        }
    };
    RegistrationComponent = __decorate([
        core_1.Component({
            selector: 'app-registration',
            templateUrl: './registration.component.html',
            styleUrls: ['./registration.component.scss']
        })
    ], RegistrationComponent);
    return RegistrationComponent;
}());
exports.RegistrationComponent = RegistrationComponent;
//# sourceMappingURL=registration.component.js.map