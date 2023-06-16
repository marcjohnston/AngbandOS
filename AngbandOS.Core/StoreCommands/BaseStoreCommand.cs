// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal abstract class BaseStoreCommand
{
    protected SaveGame SaveGame { get; }
    protected BaseStoreCommand(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
    public abstract char Key { get; }
    public virtual bool IsEnabled(Store store) => true;
    public abstract void Execute(StoreCommandEvent storeCommandEvent);
    public abstract string Description { get; }
}
