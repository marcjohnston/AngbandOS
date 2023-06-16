// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackTypes;

internal class BegAttackType : BaseAttackType
{
    public override string MonsterAction(Monster monster) => $"begs {monster.Name} for money";
    public override string PlayerAction(SaveGame saveGame) => $"begs you for money";
    public override string KnowledgeAction => "beg";
    public override bool AttackTouchesTarget => false;
    public override bool AttackAwakensTarget => true;
}
