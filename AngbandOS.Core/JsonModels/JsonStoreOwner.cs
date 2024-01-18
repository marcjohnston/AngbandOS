// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.JsonModels;

/// <summary>
/// Represents the model for a store owner to be used for Json deserialization.  All properties are nullable so that the deserialization can be validated.
/// </summary>
internal class JsonStoreOwner : IJsonModel<StoreOwnerDefinition>
{
    public string? Key { get; set; }

    public int? MaxCost { get; set; }

    public int? MinInflate { get; set; }

    public string? OwnerName { get; set; }

    public string? OwnerRaceName { get; set; }

    public StoreOwnerDefinition? ToDefinition()
    {
        if (Key == null || MaxCost == null || MinInflate == null || OwnerName == null)
            return null;

        return new StoreOwnerDefinition()
        {
            Key = Key,
            MaxCost = MaxCost.Value,
            MinInflate = MinInflate.Value,
            OwnerName = OwnerName,
            OwnerRaceName = OwnerRaceName
        };
    }
}