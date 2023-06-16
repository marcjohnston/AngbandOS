namespace AngbandOS.Core.AttackTypes;

internal class KickAttackType : BaseAttackType
{
    public override string MonsterAction(Monster monster) => $"kicks {monster.Name}";
    public override string PlayerAction(SaveGame saveGame) => $"kicks you";
    public override string KnowledgeAction => "kick";
    public override bool AttackStunsTarget => true;
}
