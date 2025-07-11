﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class Exp10AttackEffect : ExpAttackEffect
{
    private Exp10AttackEffect(Game game) : base(game) { }
    public override int Power => 5;
    public override string Description => "lower experience (by 10d6+)";
    protected override int HoldLifePercentChange => 95;
    protected override int DiceCount => 10;
}