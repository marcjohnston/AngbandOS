// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class StoreCommandGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Key Character",
        Summary = "Specifies the character used to invoke the store command.",
        DataType = "char")]
    public virtual char KeyChar { get; set; }

    [ConfigurationMetadata(
        Title = "Description",
        Summary = "Specifies the description of the store command.",
        DataType = "string")]
    public virtual string Description { get; set; }

    [ConfigurationMetadata(
        Title = "Valid Store Factory Names",
        Summary = "Specifies the store factory names for which the command is valid.",
        DataType = "string[]?")]
    public virtual string[]? ValidStoreFactoryNames { get; set; }

    [ConfigurationMetadata(
        Title = "Execute Script Name",
        Summary = "Specifies the name of the script executed by the store command.",
        DataType = "string?")]
    public virtual string? ExecuteScriptName { get; set; }
}
