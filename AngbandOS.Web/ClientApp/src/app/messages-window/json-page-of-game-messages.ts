import { JsonGameMessage } from "./json-game-message";

/// <summary>
/// Represents the json deseialized game-messages retrieved from an active game.
/// </summary>
export class JsonPageOfGameMessages {
  /** Returns the index of the most recent message in the page.  This is gameMessages[gameMessages.length - 1]. */
  public firstIndex: number | undefined;

  /** Returns the index of the oldest message in the page.  This is gameMessages[0]. */
  public lastIndex: number | undefined;

  /** Returns the page of game messages. */
  public gameMessages: JsonGameMessage[] | undefined;
}
