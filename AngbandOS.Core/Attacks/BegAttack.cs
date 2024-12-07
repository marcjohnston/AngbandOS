// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Attacks;

[Serializable]
internal class BegAttack : Attack
{
    private BegAttack(Game game) : base(game) { }
    public override string MonsterAction => "begs {0} for money";
    public override string PlayerAction => $"begs you for money";
    public override string KnowledgeAction => "beg";
    public override bool AttackTouchesTarget => false;
    public override bool AttackAwakensTarget => true;
}
