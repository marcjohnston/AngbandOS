﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.JsonModels;

internal class JsonTown : IJsonModel<TownDefinition>
{
    public string? Key { get; set; }

    public int? HousePrice { get; set; }

    public string? Name { get; set; }

    public char? Char { get; set; }

    public string[]? StoreNames { get; set; }

    public TownDefinition? ToDefinition()
    {
        if (Key == null || HousePrice == null || Name == null || Char == null || StoreNames == null)
            return null;

        return new TownDefinition()
        {
            Key = Key,
            HousePrice = HousePrice.Value,
            Name = Name,
            Char = Char.Value,
            StoreNames = StoreNames
        };
    }
}