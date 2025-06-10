
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Functions;

/// <summary>
/// Represents a boolean value function with change tracking that returns true, when trap detection has been performed on the map grid coordinates of the player.
/// </summary>
[Serializable]
internal class TrapsDetectedFunction : BoolFunction
{
    private TrapsDetectedFunction(Game game) : base(game) { } // This object is a singleton.
    public override bool BoolValue => Game.Map.Grid[Game.MapY.IntValue][Game.MapX.IntValue].TrapsDetected;

    public override string[]? DependencyNames => new string[]
    {
        nameof(MapXIntProperty),
        nameof(MapYIntProperty),
        nameof(TrapsDetectedProperty)
    };
}
