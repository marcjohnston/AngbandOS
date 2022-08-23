/**
 * Represents the client-side object to parse from the server-side JSON encoded JWT.
 **/
export class JwtClaims {
  public aud: string | undefined;
  public iss: string | undefined;
  public exp: string | undefined;
  public email: string | undefined;
  public email_verified: string | undefined;
  public username: string | undefined;
}
