"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ForgotPasswordDialogComponent = void 0;
var core_1 = require("@angular/core");
var dialog_1 = require("@angular/material/dialog");
var forgot_password_dialog_form_group_1 = require("./forgot-password-dialog-form-group");
var ForgotPasswordDialogComponent = /** @class */ (function () {
    function ForgotPasswordDialogComponent(_dialogRef, _httpClient, _snackBarService, _forgotPasswordDialogdata) {
        this._dialogRef = _dialogRef;
        this._httpClient = _httpClient;
        this._snackBarService = _snackBarService;
        this._forgotPasswordDialogdata = _forgotPasswordDialogdata;
        this.formGroup = new forgot_password_dialog_form_group_1.ForgotPasswordDialogFormGroup();
        this.message = "";
    }
    ForgotPasswordDialogComponent.prototype.ngOnInit = function () {
        this.formGroup.emailAddress.setValue(this._forgotPasswordDialogdata.emailAddress);
    };
    ForgotPasswordDialogComponent.prototype.onSendRecoveryLinkClick = function () {
        var _this = this;
        this._httpClient.get("/api/users/" + this.formGroup.emailAddress.value + "/password").toPromise().then(function () {
            _this._dialogRef.close("Password reset email sent.");
        }, function (_errorResponse) {
            _this._snackBarService.showError(_errorResponse);
            _this.message = "Unable to send password reset email.";
        });
    };
    ForgotPasswordDialogComponent = __decorate([
        core_1.Component({
            selector: 'app-forgot-password-dialog',
            templateUrl: './forgot-password-dialog.component.html',
            styleUrls: ['./forgot-password-dialog.component.scss']
        }),
        __param(3, core_1.Inject(dialog_1.MAT_DIALOG_DATA))
    ], ForgotPasswordDialogComponent);
    return ForgotPasswordDialogComponent;
}());
exports.ForgotPasswordDialogComponent = ForgotPasswordDialogComponent;
//# sourceMappingURL=forgot-password-dialog.component.js.map