// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class SaveGameData
{
    public GameStateBag Game { get; set; }
    public bool UnusedAndEmptyObjectsPruned { get; set; }
    public SaveGameData(GameStateBag game, bool unusedAndEmptyObjectsPruned)
    {
        Game = game;
        UnusedAndEmptyObjectsPruned = unusedAndEmptyObjectsPruned;
    }
}