namespace AngbandOS.Core.AttackTypes;

internal class TouchAttackType : BaseAttackType
{
    public override string MonsterAction(Monster monster) => $"touches {monster.Name}";
    public override string PlayerAction(SaveGame saveGame) => $"touches you";
    public override string KnowledgeAction => "touch";
}
