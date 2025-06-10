// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class Target
{
    /// <summary>
    /// Returns the location of the target; or null, if the target is not valid.
    /// </summary>
    public abstract GridCoordinate? GetTargetLocation();

    /// <summary>
    /// Returns the monster that is being targeted; or null, if there is no monster being targeted.  Used to detect when the targeted monster is killed so that the target
    /// can be removed.
    /// </summary>
    public virtual Monster? TargetedMonster => null;

    public abstract string SelectionMessage { get; }
}
