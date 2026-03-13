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

  /**
   * Returns true, if the user is authenticated; false, otherwise.  If the user is not logged in and there is a JWT in the local storage, the user will be logged in automatically.
   */
  public get isAuthenticated(): boolean {
    // If the user isn't logged in, check the local storage for the jwt.
    if (this.currentUser.value === null) {     
      const jwtToken = localStorage.getItem(LOCAL_STORAGE_JWT);
      if (jwtToken !== null) {
        this.parseJwt(jwtToken);
      }
    }
    return this.currentUser.value !== null;
  }

  public get isAdministrator(): boolean {
    const userDetails: UserDetails | null = this.currentUser?.value;
    if (userDetails !== null) {
      return userDetails.isAdmin;
    }
    return false;
  }

  public get username(): string | null {
    const userDetails: UserDetails | null = this.currentUser?.value;
    if (userDetails !== null) {
      return userDetails.username;
    }
    return null;
  }

  /**
   * Parses a JWT and returns the tokens.  This method is used by the administrative dashboard for debugging purposes.
   * @param jwtToken
   */
  public parseJwt(jwtToken: string): boolean {
    // Split the json web token into the three parts.
    const splitTokens: string[] = jwtToken.split('.'); // Header = [0], Payload = [1], Signature = [2]

    // Ensure there were three parts.
    if (splitTokens.length === 3) {
      // Decode the payload from base64.
      const payload: string = atob(splitTokens[1]);

      // Convert the payload into an object.  The jwt properties are always strings.
      const jwtClaims = JSON.parse(payload);
      if (jwtClaims !== null) {
        const roles: string[] = jwtClaims['https://angbandos.skarstech.com/roles'];

        // Now manually convert the claims into a user details with the correct data-types.
        const userDetails: UserDetails = {
          aud: jwtClaims.aud,
          email: jwtClaims.email,
          emailVerified: (jwtClaims.email_verified === "true"),
          exp: new Date(Number(jwtClaims.exp) * 1000), // Convert the seconds since epoch to milliseconds since epoch.
          iss: jwtClaims.iss,
          isAdmin: roles === undefined ? false : roles.includes("administrator"),
          jwt: jwtToken,
          username: jwtClaims.username
        };
        this.currentUser.next(userDetails);
        return true;
      } else {
        return false;
      }
    } else {
      return false;
    }
}

  public login(emailAddress: string, password: string): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      this._httpClient.post<LoginResponse>(`/apiv1/accounts/${encodeURI(emailAddress)}/authentication`, { password }).toPromise().then((_loginResponse: LoginResponse | undefined) => {
        if (_loginResponse !== undefined && _loginResponse.jwtToken !== null && _loginResponse.jwtToken !== undefined) {
          const jwtToken: string = _loginResponse.jwtToken as string;

          if (this.parseJwt(jwtToken)) {
            localStorage.setItem(LOCAL_STORAGE_JWT, jwtToken);
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
