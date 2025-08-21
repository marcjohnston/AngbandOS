namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents the mode for a projectile that is launched using a script interface that does not accept a directional parameter.
/// </summary>
public enum NonDirectionalProjectileModeEnum
{
    /// <summary>
    /// Specifies that the default mode for a projectile that is launched using a script interface that does not accept a directional parameter.  Default is for the player to specify a direction.
    /// </summary>
    Default = PlayerSpecified,

    /// <summary>
    /// Specifies that a projectile that is launched using a script interface that does not accept a directional parameter will request the player to specify a direction. 
    /// </summary>
    PlayerSpecified = 0,

    /// <summary>
    /// Specifies that a projectile that is launched using a script interface that does not accept a directional parameter will launch a projectile in all 8 directions.
    /// </summary>
    AllDirections = 1,

    /// <summary>
    /// Specifies that a projectile that is launched using a script interface that does not accept a directional parameter will launch a projectile at every monster that is in the players line-of-sight. 
    /// </summary>
    AllMonstersInLos = 2,

    /// <summary>
    /// Specifies that a projectile that is launched using a script interface that does not accept a directional parameter will launch the projectile at the players current location.
    /// </summary>
    AtPlayerLocation = 3
}