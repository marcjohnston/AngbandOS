﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Rolls;

[Serializable]
internal class ValueRoll : Roll
{
    public ValueRoll(Game game, int value) : base(game)
    {
        Value = value;
        MaximumValue = value;
    }
    public int Value { get; }
    public override int Get(Random random) => Value;
}