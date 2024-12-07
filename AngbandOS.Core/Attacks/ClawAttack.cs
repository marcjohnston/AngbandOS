// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Attacks;

[Serializable]
internal class ClawAttack : Attack
{
    private ClawAttack(Game game) : base(game) { }
    public override string MonsterAction => "claws {0}";
    public override string PlayerAction => $"claws you";
    public override bool AttackCutsTarget => true;
    public override string KnowledgeAction => "claw";
}
