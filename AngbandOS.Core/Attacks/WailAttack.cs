﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Attacks;

[Serializable]
internal class WailAttack : Attack
{
    private WailAttack(Game game) : base(game) { }
    public override string MonsterAction => "wails at {0}";
    public override string PlayerAction => $"wails at you";
    public override string KnowledgeAction => "wail";
    public override bool AttackTouchesTarget => false;
}
