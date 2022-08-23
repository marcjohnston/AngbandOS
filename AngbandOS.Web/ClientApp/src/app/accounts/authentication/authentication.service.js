"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.AuthenticationService = void 0;
var core_1 = require("@angular/core");
var es6_promise_1 = require("es6-promise");
var rxjs_1 = require("rxjs");
var LOCAL_STORAGE_EMAIL_ADDRESS_KEY_NAME = "email-address";
var LOCAL_STORAGE_PASSWORD_KEY_NAME = "password";
var LOCAL_STORAGE_KEEP_LOGGED_IN_KEY_NAME = "keep-logged-in";
var AuthenticationService = /** @class */ (function () {
    function AuthenticationService(_httpClient) {
        this._httpClient = _httpClient;
        this.currentUser = new rxjs_1.BehaviorSubject(null); // This is a behavior subject so that a page (e.g. account-confirmation) can detect if a login happens during init.
    }
    Object.defineProperty(AuthenticationService.prototype, "isAuthenticated", {
        get: function () {
            return this.currentUser.value !== null;
        },
        enumerable: false,
        configurable: true
    });
    AuthenticationService.prototype.userHasRight = function (rightName) {
        // Check to see if the user isn't logged in.
        if (this.currentUser.value === null)
            return null;
        // Check to see if the user has any rights.
        if (this.currentUser.value.rights === undefined || this.currentUser.value.rights === null)
            return null;
        // Check to see if the user has the associated right.
        return this.currentUser.value.rights.some(function (_rightName) { return _rightName === rightName; });
    };
    AuthenticationService.prototype.storeCredentialsLocally = function (emailAddress, password, keepLoggedIn) {
        localStorage.setItem(LOCAL_STORAGE_EMAIL_ADDRESS_KEY_NAME, emailAddress);
        localStorage.setItem(LOCAL_STORAGE_PASSWORD_KEY_NAME, password);
        localStorage.setItem(LOCAL_STORAGE_KEEP_LOGGED_IN_KEY_NAME, keepLoggedIn ? "true" : "false");
    };
    AuthenticationService.prototype.removeLocallyStoredCredentials = function () {
        localStorage.removeItem(LOCAL_STORAGE_EMAIL_ADDRESS_KEY_NAME);
        localStorage.removeItem(LOCAL_STORAGE_PASSWORD_KEY_NAME);
        localStorage.removeItem(LOCAL_STORAGE_KEEP_LOGGED_IN_KEY_NAME);
    };
    AuthenticationService.prototype.renewAuthentication = function () {
        var emailAddress = localStorage.getItem(LOCAL_STORAGE_EMAIL_ADDRESS_KEY_NAME);
        var password = localStorage.getItem(LOCAL_STORAGE_PASSWORD_KEY_NAME);
        var keepLoggedIn = localStorage.getItem(LOCAL_STORAGE_KEEP_LOGGED_IN_KEY_NAME);
        if (keepLoggedIn === "true") {
            this.login(emailAddress, password).then();
        }
    };
    /**
     * Parses a JWT and returns the tokens.  This method is used by the administrative dashboard for debugging purposes.
     * @param jwtToken
     */
    AuthenticationService.prototype.parseJwt = function (jwtToken) {
        // Split the json web token into the three parts.
        var splitTokens = jwtToken.split('.'); // Header = [0], Payload = [1], Signature = [2]
        // Ensure there were three parts.
        if (splitTokens.length === 3) {
            // Decode the payload from base64.
            var payload = atob(splitTokens[1]);
            // Convert the payload into an object.  The jwt properties are always strings.
            return JSON.parse(payload);
        }
        else {
            return null;
        }
    };
    AuthenticationService.prototype.autoLogin = function () {
        var _this = this;
        return new es6_promise_1.Promise(function (resolve, reject) {
            var emailAddress = localStorage.getItem('email-address');
            var password = localStorage.getItem('password');
            var keepLoggedIn = localStorage.getItem('keep-logged-in');
            if (keepLoggedIn && emailAddress && password) {
                _this.login(emailAddress, password).then(function () {
                    resolve();
                }, function () { return reject(); });
            }
        });
    };
    AuthenticationService.prototype.login = function (emailAddress, password) {
        var _this = this;
        return new es6_promise_1.Promise(function (resolve, reject) {
            _this._httpClient.post("/api/accounts/" + encodeURI(emailAddress) + "/authentication", { password: password }).toPromise().then(function (_loginResponse) {
                if (_loginResponse.jwtToken !== null) {
                    // Convert the payload into an object.  The jwt properties are always strings.
                    var jwtClaims = _this.parseJwt(_loginResponse.jwtToken);
                    if (jwtClaims !== null) {
                        // Now manually convert the claims into a user details with the correct data-types.
                        var rights = jwtClaims['https://www.tradingcards.wiki/rights'];
                        var userDetails = {
                            aud: jwtClaims.aud,
                            email: jwtClaims.email,
                            emailVerified: (jwtClaims.email_verified === "true"),
                            exp: new Date(Number(jwtClaims.exp) * 1000),
                            iss: jwtClaims.iss,
                            rights: rights,
                            jwt: _loginResponse.jwtToken,
                            username: jwtClaims.username
                        };
                        _this.currentUser.next(userDetails);
                        resolve();
                    }
                    else {
                        reject();
                    }
                }
                else {
                    reject();
                }
            }, function () {
                _this.currentUser.next(null);
                reject();
            }).catch(function () {
                _this.currentUser.next(null);
                reject();
            });
        });
    };
    AuthenticationService.prototype.logout = function () {
        this.currentUser.next(null);
        return true;
    };
    AuthenticationService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], AuthenticationService);
    return AuthenticationService;
}());
exports.AuthenticationService = AuthenticationService;
//# sourceMappingURL=authentication.service.js.map