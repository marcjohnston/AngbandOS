
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Functions;

/// <summary>
/// Represents a boolean function that returns true, when the player is tracking a monster and the monster is dead; false, otherwise.
/// </summary>
[Serializable]
internal class TrackedMonsterIsDeadBoolFunction : BoolFunction
{
    private TrackedMonsterIsDeadBoolFunction(Game game) : base(game) { } // This object is a singleton.
    public override bool BoolValue => Game.TrackedMonster.Value != null && Game.TrackedMonster.Value.Health < 0;
    public override string[]? DependencyNames => new string[] { nameof(TrackedMonsterNullableMonsterProperty), nameof(TrackedMonsterChangedProperty) };
}

/// <summary>
/// Represents an integer function that returns -1, when the player is not tracking a monster or the health of the monster.
/// </summary>
[Serializable]
internal class TrackedMonsterHealthIntFunction : IntFunction
{
    private TrackedMonsterHealthIntFunction(Game game) : base(game) { } // This object is a singleton.
    public override int Value => Game.TrackedMonster.Value == null ? -1 : Game.TrackedMonster.Value.Health;
    public override string[]? DependencyNames => new string[] { nameof(TrackedMonsterNullableMonsterProperty), nameof(TrackedMonsterChangedProperty) };
}


/// <summary>
/// Represents an integer function that returns -1, when the player is not tracking a monster or the health of the monster.
/// </summary>
[Serializable]
internal class TrackedMonsterMaxHealthIntFunction : IntFunction
{
    private TrackedMonsterMaxHealthIntFunction(Game game) : base(game) { } // This object is a singleton.
    public override int Value => Game.TrackedMonster.Value == null ? -1 : Game.TrackedMonster.Value.MaxHealth;
    public override string[]? DependencyNames => new string[] { nameof(TrackedMonsterNullableMonsterProperty), nameof(TrackedMonsterChangedProperty) };
}
