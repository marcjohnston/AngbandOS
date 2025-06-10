
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Functions;

/// <summary>
/// Represents a function that returns the race name for the monster that the player is tracking; or null, if the player is not tracking a monster.
/// </summary>
[Serializable]
internal class TrackedMonsterRaceNameNullableStringsFunction : NullableStringsFunction
{
    private TrackedMonsterRaceNameNullableStringsFunction(Game game) : base(game) { } // This object is a singleton.
    public override string[]? NullableStringsValue => Game.TrackedMonster.Value == null ? null : Game.TrackedMonster.Value.Race.GetMultilineName;
    public override string[]? DependencyNames => new string[] { nameof(TrackedMonsterNullableMonsterProperty) };
}
