// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents a composite interface that scripts need to implement to act as a projectile.  ProjectileScripts and ProjectileWeightedRandoms will both use this interface to ensure they 
/// both conform to all required interfaces and stay in sync with each other.
/// </summary>
internal interface IProjectile : IDirectionalActivationScript, IIdentifiedScriptDirection, IZapRodScript, IScript, IReadScrollAndUseStaffScript, IUsedScriptItem, ISuccessByChanceScript
{
}
