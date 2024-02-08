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
internal class JsonShopkeeper : IJsonModel<ShopkeeperDefinition>
{
    public string? Key { get; set; }

    public int? MaxCost { get; set; }

    public int? MinInflate { get; set; }

    public string? Name { get; set; }

    public string? RaceName { get; set; }

    public ShopkeeperDefinition? ToDefinition()
    {
        if (Key == null || MaxCost == null || MinInflate == null || Name == null)
            return null;

        return new ShopkeeperDefinition()
        {
            Key = Key,
            MaxCost = MaxCost.Value,
            MinInflate = MinInflate.Value,
            Name = Name,
            RaceName = RaceName
        };
    }
}