// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class RealmGameConfiguration
{
    public virtual string Key { get; set; }

    public virtual string[] SpellBookNames { get; set; }

    public virtual string[] Info { get; set; }

    public virtual string Name { get; set; }

    /// <summary>
    /// Returns true, if a player subscribing to the realm gains resistance to hellfire projectiles.  The resistance offers a 50% reduction in damage.  Returns false, by default.  The Death realm, returns true.
    /// </summary>
    /// <value><c>true</c> if [resistant to hell fire]; otherwise, <c>false</c>.</value>
    public virtual bool ResistantToHolyAndHellProjectiles { get; set; } = false;

    /// <summary>
    /// Returns true, if a player subscribing to the realm gains is more susceptible to hellfire projectiles.  The susceptibility costs an additional 50% increase in damage.  Returns false, by default.  The Life realm, returns true.
    /// </summary>
    /// <value><c>true</c> if [resistant to hell fire]; otherwise, <c>false</c>.</value>
    public virtual bool SusceptibleToHolyAndHellProjectiles { get; set; } = false;
}
