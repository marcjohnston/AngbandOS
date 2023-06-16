namespace AngbandOS.Core.AttackTypes;

internal class CrushAttackType : BaseAttackType
{
    public override string MonsterAction(Monster monster) => $"crushes {monster.Name}";
    public override string PlayerAction(SaveGame saveGame) => $"crushes you";
    public override string KnowledgeAction => "crush";
    public override bool AttackStunsTarget => true;
}
