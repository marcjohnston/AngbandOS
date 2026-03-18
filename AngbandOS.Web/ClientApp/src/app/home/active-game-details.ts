export class ActiveGameDetails {
  /**
   *  This property is retrieved from the game server.
   */
  public characterName: string | undefined;

  /**
   *  This property is retrieved from the game server.
   */
  public gold: number | null | undefined;

  /**
   *  This property is retrieved from the game server.
   */
  public experienceLevel: number | undefined | null;

  /**
   *  Represents the amount of time that has elapsed for the character in game time.  This is not real-world playing time.  This property is retrieved from the game server.
   */
  public elapsedGameTimeSpan: string | undefined;

  /**
   *  This property is retrieved from the game server.
   */
  public lastInputReceived: string | undefined;

  /**
   *  This property is retrieved from the game server.
   */
  public connectionId: string | undefined;

  /**
   *  This property is retrieved from the game server.
   */
  public userId: string | undefined;

  /**
   *  This property is retrieved from the game server.
   */
  public username: string | undefined;

  /**
   * Represents the amount of real-world time that has elapsed as idle time in the game.  Idle time is reset on each keystroke by the player that is sent to the game.
   */
  public idleTimeSpan: string | undefined;
}
