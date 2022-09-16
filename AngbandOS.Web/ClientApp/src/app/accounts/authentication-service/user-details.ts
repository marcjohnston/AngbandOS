/**
 * Represents the parsed JWT.  The properties of the JWT are ALWAYS strings so the data types of each property will always be a string.  This object is
 * NOT a representation of the GetUser object.
 **/
export class UserDetails {
  public aud: string | undefined;
  public iss: string | undefined;
  public exp: Date | undefined;
  public email: string | undefined;
  public emailVerified: boolean | undefined;
  public jwt: string | undefined;
  public isAdmin: boolean | undefined;
  public username: string | undefined;
}
