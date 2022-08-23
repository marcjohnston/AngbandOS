"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ResetPasswordComponent = void 0;
var core_1 = require("@angular/core");
var rxjs_1 = require("rxjs");
var reset_password_form_group_1 = require("./reset-password-form-group");
var ResetPasswordComponent = /** @class */ (function () {
    function ResetPasswordComponent(_httpClient, _activatedRoute, _snackBarService, _zone) {
        this._httpClient = _httpClient;
        this._activatedRoute = _activatedRoute;
        this._snackBarService = _snackBarService;
        this._zone = _zone;
        this._resetToken = null;
        this.formGroup = new reset_password_form_group_1.ResetPasswordFormGroup();
        this._initSubscriptions = new rxjs_1.Subscription();
        this._emailAddress = null;
        this.messages = [];
        this.errors = [];
    }
    ResetPasswordComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._initSubscriptions.add(this._activatedRoute.queryParamMap.subscribe(function (paramMap) {
            // Validate the query parameters.  There are two modes for this component: password-recovery and change-password.
            // Check to see if this is password-recovery mode.  The email address and reset-password token will be specified on the query.
            _this._emailAddress = paramMap.get("emailAddress");
            _this._resetToken = paramMap.get("token");
            if (_this._emailAddress === null || _this._emailAddress.length === 0) {
                _this.errors = _this.errors.concat("Invalid email address.  Check the URL of the link.");
            }
            if (_this._resetToken === null || _this._resetToken.length === 0) {
                _this.errors = _this.errors.concat("Invalid password reset token.  Check the URL of the link.");
            }
        }));
    };
    ResetPasswordComponent.prototype.onUpdatePasswordClick = function () {
        var _this = this;
        if (this.formGroup.valid) {
            var resetPasswordRequest = {
                resetPasswordToken: this._resetToken,
                newPassword: this.formGroup.newPassword.value
            };
            this._httpClient.post("/api/accounts/" + this._emailAddress + "/password", resetPasswordRequest).toPromise().then(function () {
                _this._zone.run(function () { _this.messages = ["Password updated."]; });
                _this.formGroup.reset();
            }, function (_errorResponse) {
                _this._snackBarService.showError(_errorResponse);
                _this._zone.run(function () { _this.messages = ["Reset failed."]; });
            });
        }
    };
    ResetPasswordComponent = __decorate([
        core_1.Component({
            selector: 'app-reset-password',
            templateUrl: './reset-password.component.html',
            styleUrls: ['./reset-password.component.scss']
        })
    ], ResetPasswordComponent);
    return ResetPasswordComponent;
}());
exports.ResetPasswordComponent = ResetPasswordComponent;
//# sourceMappingURL=reset-password.component.js.map