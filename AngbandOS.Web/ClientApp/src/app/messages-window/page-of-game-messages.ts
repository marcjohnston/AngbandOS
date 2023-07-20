import { GameMessage } from "./game-message";

/// <summary>
/// Represents valid game-messages retrieved from an active game.
/// </summary>
export class PageOfGameMessages {
  /** Returns the index of the most recent message in the page.  This is gameMessages[gameMessages.length - 1]. */
  public firstIndex: number;

  /** Returns the index of the oldest message in the page.  This is gameMessages[0]. */
  public lastIndex: number;

  /** Returns the page of game messages. */
  public gameMessages: string[];

  constructor(firstIndex: number, lastIndex: number, gameMessages: string[]) {
    this.firstIndex = firstIndex;
    this.lastIndex = lastIndex;
    this.gameMessages = gameMessages;
  }
}
