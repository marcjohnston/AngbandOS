namespace AngbandOS.Core.AttackTypes;

internal class ButtAttackType : BaseAttackType
{
    public override string MonsterAction(Monster monster) => $"butts {monster.Name}";
    public override string PlayerAction(SaveGame saveGame) => $"butts you";
    public override bool AttackStunsTarget => true;
    public override string KnowledgeAction => "butt";
}
