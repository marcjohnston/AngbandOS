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
exports.AccountConfirmationFormGroup = void 0;
var forms_1 = require("@angular/forms");
var AccountConfirmationFormGroup = /** @class */ (function (_super) {
    __extends(AccountConfirmationFormGroup, _super);
    function AccountConfirmationFormGroup() {
        return _super.call(this, {
            emailAddress: new forms_1.FormControl({ value: "", disabled: true }, forms_1.Validators.required),
            password: new forms_1.FormControl("", forms_1.Validators.required),
        }) || this;
    }
    Object.defineProperty(AccountConfirmationFormGroup.prototype, "emailAddress", {
        get: function () {
            return this.controls.emailAddress;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(AccountConfirmationFormGroup.prototype, "password", {
        get: function () {
            return this.controls.password;
        },
        enumerable: false,
        configurable: true
    });
    return AccountConfirmationFormGroup;
}(forms_1.FormGroup));
exports.AccountConfirmationFormGroup = AccountConfirmationFormGroup;
//# sourceMappingURL=account-confirmation-form-group.js.map