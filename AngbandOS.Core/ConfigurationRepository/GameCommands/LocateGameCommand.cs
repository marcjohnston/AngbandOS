// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Locate the player on the level and let them scroll the map around
/// </summary>
[Serializable]
internal class LocateGameCommand : GameCommand
{
    private LocateGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char KeyChar => 'L';

    public override void Loaded()
    {
        ExecuteScript = SaveGame.SingletonRepository.Scripts.Get(nameof(LocateScript));
    }
}
