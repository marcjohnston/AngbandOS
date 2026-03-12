import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from './login-response';
import { UserDetails } from './user-details';
import { BehaviorSubject } from 'rxjs';

export const LOCAL_STORAGE_JWT = "jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  public currentUser = new BehaviorSubject<UserDetails | null>(null); // This is a behavior subject so that a page (e.g. account-confirmation) can detect if a login happens during init.

  constructor(
    private _httpClient: HttpClient
  ) {
  }

  public get isAuthenticated(): boolean {
    return this.currentUser.value !== null;
  }

  /**
   * Parses a JWT and returns the tokens.  This method is used by the administrative dashboard for debugging purposes.
   * @param jwtToken
   */
  public parseJwt(jwtToken: string): any { // eslint-disable-line
    // Split the json web token into the three parts.
    const splitTokens: string[] = jwtToken.split('.'); // Header = [0], Payload = [1], Signature = [2]

    // Ensure there were three parts.
    if (splitTokens.length === 3) {
      // Decode the payload from base64.
      const payload: string = atob(splitTokens[1]);

      // Convert the payload into an object.  The jwt properties are always strings.
      return JSON.parse(payload);
    } else {
      return null;
    }
  }

  public login(emailAddress: string, password: string): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      this._httpClient.post<LoginResponse>(`/apiv1/accounts/${encodeURI(emailAddress)}/authentication`, { password }).toPromise().then((_loginResponse: LoginResponse | undefined) => {
        if (_loginResponse !== undefined && _loginResponse.jwtToken !== null && _loginResponse.jwtToken !== undefined) {
          const jwtToken: string = _loginResponse.jwtToken as string;
          // Convert the payload into an object.  The jwt properties are always strings.
          const jwtClaims: any = this.parseJwt(jwtToken);

          if (jwtClaims !== null) {
            localStorage.setItem(LOCAL_STORAGE_JWT, jwtClaims);
            const roles: string[] = jwtClaims['https://angbandos.skarstech.com/roles'];

            // Now manually convert the claims into a user details with the correct data-types.
            const userDetails: UserDetails = {
              aud: jwtClaims.aud,
              email: jwtClaims.email,
              emailVerified: (jwtClaims.email_verified === "true"),
              exp: new Date(Number(jwtClaims.exp) * 1000), // Convert the seconds since epoch to milliseconds since epoch.
              iss: jwtClaims.iss,
              isAdmin: roles === undefined ? false : roles.includes("administrator"),
              jwt: _loginResponse.jwtToken,
              username: jwtClaims.username
            };
            this.currentUser.next(userDetails);
            resolve();
          } else {
            reject();
          }
        } else {
          reject();
        }
      }, (reason: any) => {
        this.currentUser.next(null);
        reject(reason)
      }).catch(() => {
        this.currentUser.next(null);
        reject();
      });
    })
  }

  public logout(): boolean {
    localStorage.removeItem(LOCAL_STORAGE_JWT);
    this.currentUser.next(null);
    return true;
  }
}
