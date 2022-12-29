namespace AngbandOS.Core.AttackTypes
{
    internal class ChargeAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"charges {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => $"charges you";
        public override string KnowledgeAction => "charge";
    }
}
