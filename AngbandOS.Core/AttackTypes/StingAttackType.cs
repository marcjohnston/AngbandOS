namespace AngbandOS.Core.AttackTypes;

internal class StingAttackType : BaseAttackType
{
    public override string MonsterAction(Monster monster) => $"stings {monster.Name}";
    public override string PlayerAction(SaveGame saveGame) => $"stings you";
    public override string KnowledgeAction => "string";
}
