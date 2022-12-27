namespace AngbandOS.Core.AttackTypes
{
    internal class EngulfAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"engulfs {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => $"engulfs you";
        public override string KnowledgeAction => "engulf";
    }
}
