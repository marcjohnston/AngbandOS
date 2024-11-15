// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Flags]
internal enum ProjectionFlag
{
    ProjectNone = 0x00,

    /// <summary>
    /// Allows the projectile or spell to skip directly to the target location, ignoring any intermediate grids or obstacles.
    /// </summary>
    ProjectJump = 0x01,

    /// <summary>
    /// Causes the effect to travel in a line, potentially hitting multiple targets along a straight path. Useful in corridors or for reaching enemies aligned with the caster.
    /// </summary>
    ProjectBeam = 0x02,

    /// <summary>
    /// Lets the effect pass through targets or objects without stopping, continuing on to hit entities or objects further along its trajectory.
    /// </summary>
    ProjectThru = 0x04,

    /// <summary>
    /// Causes a projectile or spell to stop when it hits an obstacle, halting further movement or effects along its path.
    /// </summary>
    ProjectStop = 0x08,

    /// <summary>
    /// Allows the effect to interact with each grid (tile or cell) it moves through, which can alter terrain or affect grid-based elements like traps.
    /// </summary>
    ProjectGrid = 0x10,

    /// <summary>
    /// Enables the effect to interact with items it encounters, possibly damaging or destroying them if applicable.
    /// </summary>
    ProjectItem = 0x20,

    /// <summary>
    /// Permits the projectile or spell to affect monsters or entities in its path, enabling damage or other targeted effects.
    /// </summary>
    ProjectKill = 0x40,

    /// <summary>
    /// Makes the projectile or spell hidden from the player’s view, often used when visual representation is unnecessary.
    /// </summary>
    ProjectHide = 0x80,
}