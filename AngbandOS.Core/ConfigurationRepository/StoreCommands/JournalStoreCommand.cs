// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

/// <summary>
/// Look in the player's journal for any one of a number of different reasons
/// </summary>
[Serializable]
internal class JournalStoreCommand : StoreCommand
{
    private JournalStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char KeyChar => 'J';

    public override string Description => "";

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        SaveGame.RunScript(nameof(JournalScript));
        storeCommandEvent.RequiresRerendering = true;
    }
}
