// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class TownGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("char",
        Title = "Character",
        Description = "Specifies the ASCII character used to represent the town.")]
    public virtual char Char { get; set; }

    [ConfigurationProperty("int",
        Title = "House Price",
        Description = "Specifies the price of a house in the town.")]
    public virtual int HousePrice { get; set; }

    [ConfigurationProperty("string",
        Title = "Name",
        Description = "Specifies the name of the town.")]
    public virtual string Name { get; set; }

    [ConfigurationProperty("string[]",
        Title = "Store Factory Names",
        Description = "Specifies the store factory names available in the town.")]
    [ConfigurationForeignKey("StoreFactories")]
    public virtual string[] StoreFactoryNames { get; set; }

    [ConfigurationProperty("bool",
        Title = "Can Be Escorted Here",
        Description = "Determines whether the player can be escorted to the town.")]
    public virtual bool CanBeEscortedHere { get; set; } = true;

    [ConfigurationProperty("bool",
        Title = "Allow Startup Town",
        Description = "Determines whether the town can be used as the startup town.")]
    public virtual bool AllowStartupTown { get; set; } = true;

    [ConfigurationProperty("string",
        Title = "Dungeon",
        Description = "Specifies the name of the dungeon associated with the town.")]
    [ConfigurationForeignKey("Dungeons")]
    public virtual string DungeonName { get; set; }

    [ConfigurationProperty("bool",
        Title = "Unused Store Lots Are Graveyards",
        Description = "Determines whether unused store lots are treated as graveyards.")]
    public virtual bool UnusedStoreLotsAreGraveyards { get; set; } = false;
}
