// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RealmGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string[]",
        Title = "Spell Book Names",
        Description = "Specifies the spell book names associated with the realm.")]
    public virtual string[] SpellBookNames { get; set; }

    [ConfigurationProperty("string[]",
        Title = "Info",
        Description = "Specifies the informational text associated with the realm.")]
    public virtual string[] Info { get; set; }

    [ConfigurationProperty("string",
        Title = "Name",
        Description = "Specifies the name of the realm.")]
    public virtual string Name { get; set; }

    [ConfigurationProperty("bool",
        Title = "Resistant To Holy And Hell Projectiles",
        Description = "Determines whether subscribing to the realm grants resistance to holy and hell projectiles.")]
    public virtual bool ResistantToHolyAndHellProjectiles { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Susceptible To Holy And Hell Projectiles",
        Description = "Determines whether subscribing to the realm increases susceptibility to holy and hell projectiles.")]
    public virtual bool SusceptibleToHolyAndHellProjectiles { get; set; } = false;
}
