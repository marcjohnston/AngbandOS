namespace AngbandOS.Core.AttackTypes
{
    internal  class DroolAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"drools on {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => $"drools on you";
        public override string KnowledgeAction => "drool on you";
        public override bool AttackTouchesTarget => false;
    }
}
