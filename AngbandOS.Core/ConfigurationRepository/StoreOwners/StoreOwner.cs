// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreOwners;

[Serializable]
internal abstract class StoreOwner : IConfigurationItem
{
    protected SaveGame SaveGame { get; }
    protected StoreOwner(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <inheritdoc />
    public virtual void Loaded() { }

    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;

    public abstract int MaxCost { get; }
    public abstract int MinInflate { get; }
    public abstract string OwnerName { get; }

    /// <summary>
    /// Returns the race of the store owner.  Null, if there is no store owner.
    /// </summary>
    public abstract Race? OwnerRace { get; }
}
