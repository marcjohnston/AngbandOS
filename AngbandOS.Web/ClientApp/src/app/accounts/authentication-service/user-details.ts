/**
 * Represents the parsed JWT.  The properties of the JWT are ALWAYS strings so the data types of each property will always be a string.  This object is
 * NOT a representation of the GetUser object.
 **/
export interface UserDetails {
  aud: string;
  iss: string;
  exp: Date;
  email: string;
  emailVerified: boolean;
  jwt: string;
  isAdmin: boolean;
  username: string;
}
