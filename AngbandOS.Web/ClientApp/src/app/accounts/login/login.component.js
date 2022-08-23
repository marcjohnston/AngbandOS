"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.LoginComponent = void 0;
var core_1 = require("@angular/core");
var rxjs_1 = require("rxjs");
var forgot_password_dialog_component_1 = require("../forgot-password-dialog/forgot-password-dialog.component");
var login_form_group_1 = require("./login-form-group");
var LoginComponent = /** @class */ (function () {
    function LoginComponent(_forgotPasswordDialog, _authenticationService, _activatedRoute, _router, _zone) {
        this._forgotPasswordDialog = _forgotPasswordDialog;
        this._authenticationService = _authenticationService;
        this._activatedRoute = _activatedRoute;
        this._router = _router;
        this._zone = _zone;
        this.formGroup = new login_form_group_1.LoginFormGroup();
        this.message = "";
        this._return = null;
        this._initSubscriptions = new rxjs_1.Subscription();
    }
    LoginComponent.prototype.ngOnDestroy = function () {
        this._initSubscriptions.unsubscribe();
    };
    LoginComponent.prototype.ngOnInit = function () {
        var _this = this;
        // Get the query params
        this._activatedRoute.queryParams.subscribe(function (params) {
            // Get the return URL, if one was specified.
            _this._return = params['return'];
            // Setup the formgroup values.
            var emailAddress = localStorage.getItem('email-address');
            var password = localStorage.getItem('password');
            var keepLoggedIn = localStorage.getItem('keep-logged-in');
            _this.formGroup.emailAddress.setValue(emailAddress);
            _this.formGroup.password.setValue(password);
            _this.formGroup.keepLoggedIn.setValue(keepLoggedIn);
            // We need subscriptions to erase the message when the username or password form fields are changed.
            _this._initSubscriptions.add(_this.formGroup.emailAddress.valueChanges.subscribe(function () { return _this.message = ""; }));
            _this._initSubscriptions.add(_this.formGroup.password.valueChanges.subscribe(function () { return _this.message = ""; }));
        });
    };
    Object.defineProperty(LoginComponent.prototype, "isAuthenticated", {
        get: function () {
            return this._authenticationService.isAuthenticated;
        },
        enumerable: false,
        configurable: true
    });
    LoginComponent.prototype.onLoginClick = function () {
        var _this = this;
        this._authenticationService.login(this.formGroup.emailAddress.value, this.formGroup.password.value).then(function () {
            if (_this._return !== null) {
                if (_this.formGroup.rememberMe.value) {
                    _this._authenticationService.storeCredentialsLocally(_this.formGroup.emailAddress.value, _this.formGroup.password.value, _this.formGroup.keepLoggedIn.value);
                }
                else {
                    _this._authenticationService.removeLocallyStoredCredentials();
                }
                // This is running outside of the Angular zone.
                _this._zone.run(function () { return _this._router.navigate([_this._return]); });
            }
            else {
                _this._zone.run(function () { _this.message = ""; });
            }
        }, function () {
            // Erase the password.  We need to do this before the setting the message because we have a subscription that will erase the message.
            _this.formGroup.password.setValue("");
            // Now set the message.
            _this.message = "Login failed.";
        });
    };
    LoginComponent.prototype.onForgotPasswordClick = function () {
        var _this = this;
        var data = {
            emailAddress: this.formGroup.emailAddress.value
        };
        var matDialogRef = this._forgotPasswordDialog.open(forgot_password_dialog_component_1.ForgotPasswordDialogComponent, {
            height: '200px',
            width: '450px',
            data: data
        });
        this._initSubscriptions.add(matDialogRef.afterClosed().subscribe(function (message) {
            _this.message = message;
        }));
    };
    LoginComponent = __decorate([
        core_1.Component({
            selector: 'app-login',
            templateUrl: './login.component.html',
            styleUrls: ['./login.component.scss']
        })
    ], LoginComponent);
    return LoginComponent;
}());
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map