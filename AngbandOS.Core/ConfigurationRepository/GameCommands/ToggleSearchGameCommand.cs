// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Toggle whether we're automatically searching while moving
/// </summary>
[Serializable]
internal class ToggleSearchGameCommand : GameCommand
{
    private ToggleSearchGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char KeyChar => 'S';

    public override void Loaded()
    {
        ExecuteScript = SaveGame.SingletonRepository.Scripts.Get(nameof(ToggleSearchScript));
    }
}
