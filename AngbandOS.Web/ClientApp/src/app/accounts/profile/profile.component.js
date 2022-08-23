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
exports.ProfileComponent = void 0;
var core_1 = require("@angular/core");
var rxjs_1 = require("rxjs");
var profile_form_group_1 = require("./profile-form-group");
var ProfileComponent = /** @class */ (function () {
    function ProfileComponent(_httpClient, _activatedRoute, _snackBarService, _authenticationService) {
        this._httpClient = _httpClient;
        this._activatedRoute = _activatedRoute;
        this._snackBarService = _snackBarService;
        this._authenticationService = _authenticationService;
        this.formGroup = new profile_form_group_1.ProfileFormGroup();
        this._initSubscriptions = new rxjs_1.Subscription();
    }
    ProfileComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.formGroup.emailAddress.setValue(this._authenticationService.currentUser.value.email);
        this.formGroup.username.setValue(this._authenticationService.currentUser.value.username);
        this.formGroup.disable();
        this._initSubscriptions.add(this._activatedRoute.queryParamMap.subscribe(function (paramMap) {
            // Validate the query parameters.
            // We will be expecting an email address parameter if this is an email validation.
            console.log(paramMap.get("confirm"));
            if (paramMap.get("confirm") === "true") {
                _this.sendConfirmationEmail();
            }
        }));
    };
    ProfileComponent.prototype.ngOnDestroy = function () {
        this._initSubscriptions.unsubscribe();
    };
    ProfileComponent.prototype.onEditClick = function () {
        this.formGroup.enable();
    };
    Object.defineProperty(ProfileComponent.prototype, "emailVerified", {
        get: function () {
            return this._authenticationService.currentUser.value.emailVerified;
        },
        enumerable: false,
        configurable: true
    });
    ProfileComponent.prototype.sendConfirmationEmail = function () {
        var _this = this;
        this.messages = ["Sending confirmation email ..."];
        var emailAddress = this._authenticationService.currentUser.value.email;
        this._httpClient.get("/api/users/" + encodeURI(emailAddress) + "/verification").toPromise().then(function () {
            _this.messages = ["Confirmation email sent."];
        }, function (_errorResponse) {
            _this._snackBarService.showError(_errorResponse);
            _this.messages = __spreadArrays(_errorResponse.error);
        });
    };
    ProfileComponent.prototype.onResendConfirmationEmailClick = function () {
        this.sendConfirmationEmail();
    };
    ProfileComponent.prototype.onSaveClick = function () {
        this.formGroup.disable();
    };
    ProfileComponent.prototype.onCancelClick = function () {
        this.formGroup.disable();
    };
    ProfileComponent = __decorate([
        core_1.Component({
            selector: 'app-profile',
            templateUrl: './profile.component.html',
            styleUrls: ['./profile.component.scss']
        })
    ], ProfileComponent);
    return ProfileComponent;
}());
exports.ProfileComponent = ProfileComponent;
//# sourceMappingURL=profile.component.js.map