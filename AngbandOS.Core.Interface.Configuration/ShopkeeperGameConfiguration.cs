// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Shopkeeper",
    EntityNoun = "shopkeeper")]
public class ShopkeeperGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Maximum Cost",
        Summary = "Specifies the maximum cost of items handled by the shopkeeper.",
        DataType = "int")]
    public virtual int MaxCost { get; set; }

    [ConfigurationMetadata(
        Title = "Minimum Inflate",
        Summary = "Specifies the minimum inflation applied by the shopkeeper.",
        DataType = "int")]
    public virtual int MinInflate { get; set; }

    [ConfigurationMetadata(
        Title = "Name",
        Summary = "Specifies the name of the shopkeeper.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationMetadata(
        Title = "Race Name",
        Summary = "Specifies the race name of the shopkeeper. When null, no race is specified.",
        DataType = "string?")]
    public virtual string? RaceName { get; set; }
}

