"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.ChangePasswordFormGroup = exports.passwordsMatch = void 0;
var forms_1 = require("@angular/forms");
exports.passwordsMatch = function (control) {
    var newPassword = control.get('newPassword').value;
    var confirmPassword = control.get('confirmPassword').value;
    return newPassword !== confirmPassword ? { confirmPasswordMismatch: true } : null;
};
var ChangePasswordFormGroup = /** @class */ (function (_super) {
    __extends(ChangePasswordFormGroup, _super);
    function ChangePasswordFormGroup() {
        return _super.call(this, {
            currentPassword: new forms_1.FormControl("", forms_1.Validators.required),
            newPassword: new forms_1.FormControl("", forms_1.Validators.required),
            confirmPassword: new forms_1.FormControl("", forms_1.Validators.required),
        }, { validators: exports.passwordsMatch }) || this;
    }
    Object.defineProperty(ChangePasswordFormGroup.prototype, "currentPassword", {
        get: function () {
            return this.controls.currentPassword;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(ChangePasswordFormGroup.prototype, "newPassword", {
        get: function () {
            return this.controls.newPassword;
        },
        enumerable: false,
        configurable: true
    });
    return ChangePasswordFormGroup;
}(forms_1.FormGroup));
exports.ChangePasswordFormGroup = ChangePasswordFormGroup;
//# sourceMappingURL=change-password-form-group.js.map