
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Functions;

/// <summary>
/// Represents a boolean function that returns true, when the player is tracking a monster and that monster is not visible; false, otherwise.  This function has no dependencies
/// and will evaluate everytime it is referenced.
/// </summary>
[Serializable]
internal class PlayerIsHallucinatingBoolFunction : BoolFunction
{
    private PlayerIsHallucinatingBoolFunction(Game game) : base(game) { } // This object is a singleton.
    public override bool BoolValue => Game.HallucinationsTimer.Value != 0;
    public override string[]? DependencyNames => new string[] { nameof(HallucinatingTimer) };
}
