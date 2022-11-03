export class ActiveGameDetails {
  public username: string | undefined;
  public userId: string | undefined;
  public connectionId: string | undefined;
  public level: number | undefined | null;
  public gold: number | null | undefined;
  public characterName: string | undefined;
  public elapsedGameTime: string | undefined;
  public lastInputReceived: string | undefined;
  public idleTimeSpan: string | undefined;
}
