"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.AccountConfirmationComponent = void 0;
var core_1 = require("@angular/core");
var rxjs_1 = require("rxjs");
var account_confirmation_form_group_1 = require("./account-confirmation-form-group");
var AccountConfirmationComponent = /** @class */ (function () {
    function AccountConfirmationComponent(_router, _activatedRoute, _snackBarService, _authenticationService, _httpClient, _zone) {
        this._router = _router;
        this._activatedRoute = _activatedRoute;
        this._snackBarService = _snackBarService;
        this._authenticationService = _authenticationService;
        this._httpClient = _httpClient;
        this._zone = _zone;
        this._initSubscriptions = new rxjs_1.Subscription();
        this.errors = [];
        this.messages = [];
        this.formGroup = new account_confirmation_form_group_1.AccountConfirmationFormGroup();
        this.emailAddress = null; // This is the email address supplied in the query.
        this.verificationToken = null; // This is the verification token supplied in the query.
    }
    AccountConfirmationComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._initSubscriptions.add(this._activatedRoute.queryParamMap.subscribe(function (paramMap) {
            // Validate the query parameters.
            // We will be expecting an email address parameter if this is an email validation.
            _this.emailAddress = paramMap.get("emailAddress");
            _this.verificationToken = paramMap.get("token");
            _this.formGroup.emailAddress.setValue(_this.emailAddress); // This is ONLY a visual cue for the user.
            _this.errors = [];
            if (_this.emailAddress === null || _this.emailAddress.length === 0) {
                _this.errors = _this.errors.concat("Invalid email address.");
            }
            if (_this.verificationToken === null || _this.verificationToken.length === 0) {
                _this.errors = _this.errors.concat("Invalid verification token.");
            }
            // Attempt a verification.
            _this.verify();
        }));
        // Subscribe to changes in the login.  This may be performed by the user or an automatic login.
        this._initSubscriptions.add(this._authenticationService.currentUser.subscribe(function (u) {
            // Being that current user is a behavior subject, the first call not still not be authenticated.
            _this.verify();
        }));
    };
    AccountConfirmationComponent.prototype.ngOnDestroy = function () {
        this._initSubscriptions.unsubscribe();
    };
    Object.defineProperty(AccountConfirmationComponent.prototype, "isAuthenticated", {
        /**
         * Returns true, if the current authenticated user matches the email-address query token; false, otherwise.
         */
        get: function () {
            var emailAddressIsValid = (this.emailAddress !== null && this.emailAddress.length > 0);
            return (emailAddressIsValid && this._authenticationService.isAuthenticated && this._authenticationService.currentUser.value.email === this.emailAddress);
        },
        enumerable: false,
        configurable: true
    });
    AccountConfirmationComponent.prototype.verify = function () {
        var _this = this;
        // This method may be called even if the user is not authenticated.
        if (this.errors.length === 0 && this.isAuthenticated) {
            var putUser = {
                token: this.verificationToken
            };
            this._httpClient.put("/api/accounts/" + this.emailAddress + "/verification", putUser).toPromise().then(function () {
                _this._zone.run(function () { _this.messages = ["Account confirmed."]; });
                _this._authenticationService.currentUser.value.emailVerified = true;
            }, function (_errorResponse) {
                _this._snackBarService.showError(_errorResponse);
            });
        }
    };
    AccountConfirmationComponent.prototype.onLoginClick = function () {
        var _this = this;
        this.messages = ["Updating your account."];
        // The user needed to login.  Log the user in an then check the verification.
        this._authenticationService.login(this.emailAddress, this.formGroup.password.value).then(function () {
            //this.verify();
        }, function () {
            _this.messages = ["Login failed."];
        });
    };
    AccountConfirmationComponent.prototype.onForgotPasswordClick = function () {
    };
    AccountConfirmationComponent = __decorate([
        core_1.Component({
            selector: 'app-account-confirmation',
            templateUrl: './account-confirmation.component.html',
            styleUrls: ['./account-confirmation.component.scss']
        })
    ], AccountConfirmationComponent);
    return AccountConfirmationComponent;
}());
exports.AccountConfirmationComponent = AccountConfirmationComponent;
//# sourceMappingURL=account-confirmation.component.js.map
