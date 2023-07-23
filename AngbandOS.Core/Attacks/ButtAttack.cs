// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackTypes;

[Serializable]
internal class ButtAttack : Attack
{
    private ButtAttack(SaveGame saveGame) : base(saveGame) { }
    public override string MonsterAction(Monster monster) => $"butts {monster.Name}";
    public override string PlayerAction => $"butts you";
    public override bool AttackStunsTarget => true;
    public override string KnowledgeAction => "butt";
}
