// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Town",
    EntityNoun = "town")]
public class TownGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Character",
        Summary = "Specifies the character used to represent the town.",
        DataType = "char")]
    public virtual char Char { get; set; }

    [ConfigurationMetadata(
        Title = "House Price",
        Summary = "Specifies the price of a house in the town.",
        DataType = "int")]
    public virtual int HousePrice { get; set; }

    [ConfigurationMetadata(
        Title = "Name",
        Summary = "Specifies the name of the town.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationMetadata(
        Title = "Store Factory Names",
        Summary = "Specifies the store factory names available in the town.",
        DataType = "string[]")]
    public virtual string[] StoreFactoryNames { get; set; }

    [ConfigurationMetadata(
        Title = "Can Be Escorted Here",
        Summary = "Determines whether the player can be escorted to the town.",
        DataType = "bool")]
    public virtual bool CanBeEscortedHere { get; set; } = true;

    [ConfigurationMetadata(
        Title = "Allow Startup Town",
        Summary = "Determines whether the town can be used as the startup town.",
        DataType = "bool")]
    public virtual bool AllowStartupTown { get; set; } = true;

    [ConfigurationMetadata(
        Title = "Dungeon Name",
        Summary = "Specifies the name of the dungeon associated with the town.",
        DataType = "string")]
    public virtual string DungeonName { get; set; }

    [ConfigurationMetadata(
        Title = "Unused Store Lots Are Graveyards",
        Summary = "Determines whether unused store lots are treated as graveyards.",
        DataType = "bool")]
    public virtual bool UnusedStoreLotsAreGraveyards { get; set; } = false;
}
