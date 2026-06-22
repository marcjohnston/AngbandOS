import { GameRecovery } from "./game-recovery";
import { SavedGame } from "./saved-game";


export class AvailableGames {
  public savedGames: SavedGame[] | undefined;
  public gameRecoveries: GameRecovery[] | undefined;
}

