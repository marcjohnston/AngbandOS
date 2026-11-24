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
    [ConfigurationProperty("char",
        Title = "Key Character",
        Description = "Specifies the character used to invoke the store command.")]
    public virtual char KeyChar { get; set; }

    [ConfigurationProperty("string",
        Title = "Description",
        Description = "Specifies the description of the store command.")]
    public virtual string Description { get; set; }

    [ConfigurationProperty("string[]?",
        Title = "Valid Store Factory Names",
        Description = "Specifies the store factory names for which the command is valid.")]
    public virtual string[]? ValidStoreFactoryNames { get; set; }

    [ConfigurationProperty("string?",
        Title = "Execute Script Name",
        Description = "Specifies the name of the script executed by the store command.")]
    public virtual string? ExecuteScriptName { get; set; }
}
