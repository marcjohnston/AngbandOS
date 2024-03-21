// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

internal interface IFixedArtifactActivatible
{
    /// <summary>
    /// Activates the special ability of the fixed artifact.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <param name="item"></param>
    public abstract void ActivateItem(Item item);

    /// <summary>
    /// Returns the description of the activation effect for the fixed artifact.
    /// </summary>
    /// <returns></returns>
    public abstract string DescribeActivationEffect { get; }
}
