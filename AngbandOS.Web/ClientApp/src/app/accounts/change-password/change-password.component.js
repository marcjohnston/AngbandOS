"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ChangePasswordComponent = void 0;
var core_1 = require("@angular/core");
var change_password_form_group_1 = require("./change-password-form-group");
var ChangePasswordComponent = /** @class */ (function () {
    function ChangePasswordComponent(_httpClient, _authenticationService, _snackBarService, _zone) {
        this._httpClient = _httpClient;
        this._authenticationService = _authenticationService;
        this._snackBarService = _snackBarService;
        this._zone = _zone;
        this.formGroup = new change_password_form_group_1.ChangePasswordFormGroup();
        this.messages = [];
    }
    ChangePasswordComponent.prototype.onChangePasswordClick = function () {
        var _this = this;
        if (this.formGroup.valid) {
            var changePasswordRequest = {
                currentPassword: this.formGroup.currentPassword.value,
                newPassword: this.formGroup.newPassword.value
            };
            this._httpClient.put("/api/users/" + this._authenticationService.currentUser.value.email + "/password", changePasswordRequest).toPromise().then(function () {
                _this._zone.run(function () { _this.messages = ["Password updated."]; });
                _this.formGroup.reset();
            }, function (_errorResponse) {
                _this._snackBarService.showError(_errorResponse);
                _this._zone.run(function () { _this.messages = ["Update failed."]; });
            });
        }
    };
    ChangePasswordComponent = __decorate([
        core_1.Component({
            selector: 'app-change-password',
            templateUrl: './change-password.component.html',
            styleUrls: ['./change-password.component.scss']
        })
    ], ChangePasswordComponent);
    return ChangePasswordComponent;
}());
exports.ChangePasswordComponent = ChangePasswordComponent;
//# sourceMappingURL=change-password.component.js.map