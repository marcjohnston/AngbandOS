﻿
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Functions;

/// <summary>
/// Represents a boolean function that returns true, when the player is tracking a monster and that monster is afraid; false, otherwise.
/// </summary>
[Serializable]
internal class TrackedMonsterIsAfraidBoolFunction : BoolFunction
{
    private TrackedMonsterIsAfraidBoolFunction(Game game) : base(game) { } // This object is a singleton.
    public override bool BoolValue => Game.TrackedMonster.Value != null && Game.TrackedMonster.Value.FearLevel != 0;
    public override string[]? DependencyNames => new string[] { nameof(TrackedMonsterNullableMonsterProperty), nameof(TrackedMonsterChangedProperty) };
}
