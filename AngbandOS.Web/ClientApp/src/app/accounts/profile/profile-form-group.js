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
exports.RegisterFormGroup = exports.passwordsMatch = void 0;
var forms_1 = require("@angular/forms");
exports.passwordsMatch = function (control) {
    var password = control.get('password').value;
    var confirmPassword = control.get('confirmPassword').value;
    return password !== confirmPassword ? { confirmPasswordMismatch: true } : null;
};
var RegisterFormGroup = /** @class */ (function (_super) {
    __extends(RegisterFormGroup, _super);
    function RegisterFormGroup() {
        return _super.call(this, {
            emailAddress: new forms_1.FormControl("", forms_1.Validators.required),
            password: new forms_1.FormControl("", forms_1.Validators.required),
            confirmPassword: new forms_1.FormControl("", forms_1.Validators.required),
        }, { validators: exports.passwordsMatch }) || this;
    }
    Object.defineProperty(RegisterFormGroup.prototype, "emailAddress", {
        get: function () {
            return this.controls.emailAddress;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(RegisterFormGroup.prototype, "password", {
        get: function () {
            return this.controls.password;
        },
        enumerable: false,
        configurable: true
    });
    return RegisterFormGroup;
}(forms_1.FormGroup));
exports.RegisterFormGroup = RegisterFormGroup;
//# sourceMappingURL=register-form-group.js.map