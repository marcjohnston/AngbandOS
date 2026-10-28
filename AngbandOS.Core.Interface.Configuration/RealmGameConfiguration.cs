// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Realm",
    EntityNoun = "realm")]
public class RealmGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Spell Book Names",
        Summary = "Specifies the spell book names associated with the realm.",
        DataType = "string[]")]
    public virtual string[] SpellBookNames { get; set; }

    [ConfigurationMetadata(
        Title = "Info",
        Summary = "Specifies the informational text associated with the realm.",
        DataType = "string[]")]
    public virtual string[] Info { get; set; }

    [ConfigurationMetadata(
        Title = "Name",
        Summary = "Specifies the name of the realm.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationMetadata(
        Title = "Resistant To Holy And Hell Projectiles",
        Summary = "Determines whether subscribing to the realm grants resistance to holy and hell projectiles.",
        DataType = "bool")]
    public virtual bool ResistantToHolyAndHellProjectiles { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Susceptible To Holy And Hell Projectiles",
        Summary = "Determines whether subscribing to the realm increases susceptibility to holy and hell projectiles.",
        DataType = "bool")]
    public virtual bool SusceptibleToHolyAndHellProjectiles { get; set; } = false;
}
