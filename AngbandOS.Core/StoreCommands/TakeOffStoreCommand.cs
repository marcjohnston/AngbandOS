// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

/// <summary>
/// Take off an item
/// </summary>
[Serializable]
internal class TakeOffStoreCommand : BaseStoreCommand
{
    private TakeOffStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 't';

    public override string Description => "";

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        SaveGame.RunScript<TakeOffScript>();
    }
}
