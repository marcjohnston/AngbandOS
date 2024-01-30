// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.ConfigurationRepository.StoreOwners;

[Serializable]
internal class GenericStoreOwner : StoreOwner
{
    public GenericStoreOwner(SaveGame saveGame, StoreOwnerDefinition storeOwner) : base(saveGame)
    {
        Key = storeOwner.Key;
        MaxCost = storeOwner.MaxCost;
        MinInflate = storeOwner.MinInflate;
        OwnerName = storeOwner.OwnerName;
        OwnerRaceName = storeOwner.OwnerRaceName;
    }

    public override string Key { get; }

    public override int MaxCost { get; }

    public override int MinInflate { get; }

    public override string OwnerName { get; }

    protected override string? OwnerRaceName { get; }
}
