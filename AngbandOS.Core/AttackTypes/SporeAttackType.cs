namespace AngbandOS.Core.AttackTypes;

internal class SporeAttackType : BaseAttackType
{
    public override string MonsterAction(Monster monster) => $"releases spores at {monster.Name}";
    public override string PlayerAction(SaveGame saveGame) => $"releases spores at you";
    public override string KnowledgeAction => "release spores";
    public override bool AttackTouchesTarget => false;
}
