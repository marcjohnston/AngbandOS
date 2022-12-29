namespace AngbandOS.Core.AttackTypes
{
    internal class BiteAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"bites {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => $"bites you";
        public override string KnowledgeAction => "bite";
        public override bool AttackCutsTarget => true;
    }
}
