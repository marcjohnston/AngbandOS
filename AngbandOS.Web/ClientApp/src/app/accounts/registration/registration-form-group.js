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
exports.RegistrationFormGroup = exports.passwordsMatch = void 0;
var forms_1 = require("@angular/forms");
exports.passwordsMatch = function (control) {
    var password = control.get('password').value;
    var confirmPassword = control.get('confirmPassword').value;
    return password !== confirmPassword ? { confirmPasswordMismatch: true } : null;
};
var RegistrationFormGroup = /** @class */ (function (_super) {
    __extends(RegistrationFormGroup, _super);
    function RegistrationFormGroup() {
        return _super.call(this, {
            username: new forms_1.FormControl("", [forms_1.Validators.required, forms_1.Validators.pattern("^[a-zA-Z]{1}[a-zA-Z0-9]{4}$")]),
            emailAddress: new forms_1.FormControl("", [forms_1.Validators.required, forms_1.Validators.email]),
            password: new forms_1.FormControl("", forms_1.Validators.required),
            confirmPassword: new forms_1.FormControl("", forms_1.Validators.required),
        }, { validators: exports.passwordsMatch }) || this;
    }
    Object.defineProperty(RegistrationFormGroup.prototype, "username", {
        get: function () {
            return this.controls.username;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(RegistrationFormGroup.prototype, "usernameError", {
        get: function () {
            if (this.username.hasError('required')) {
                return "This field is required.";
            }
            var username = this.username.value;
            if (username.length < 5) {
                return "Must be at least 5 characters in length.";
            }
            return this.username.hasError('pattern') ? 'Alphanumeric only and must start with a letter.' : '';
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(RegistrationFormGroup.prototype, "emailAddress", {
        get: function () {
            return this.controls.emailAddress;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(RegistrationFormGroup.prototype, "emailError", {
        get: function () {
            if (this.emailAddress.hasError('required')) {
                return "This field is required.";
            }
            return this.emailAddress.hasError('email') ? 'Invalid email address.' : '';
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(RegistrationFormGroup.prototype, "password", {
        get: function () {
            return this.controls.password;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(RegistrationFormGroup.prototype, "passwordError", {
        get: function () {
            return this.password.hasError('required') ? "This field is required." : "";
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(RegistrationFormGroup.prototype, "confirmPassword", {
        get: function () {
            return this.controls.confirmPassword;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(RegistrationFormGroup.prototype, "confirmError", {
        get: function () {
            return this.hasError('confirmPasswordMismatch') ? 'Passwords do not match.' : '';
        },
        enumerable: false,
        configurable: true
    });
    return RegistrationFormGroup;
}(forms_1.FormGroup));
exports.RegistrationFormGroup = RegistrationFormGroup;
//# sourceMappingURL=registration-form-group.js.map