namespace AngbandOS.Core.AttackTypes
{
    internal class BegAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"begs {monster.Name} for money";
        public override string PlayerAction(SaveGame saveGame) => $"begs you for money";
        public override string KnowledgeAction => "beg";
        public override bool AttackTouchesTarget => false;
        public override bool AttackAwakensTarget => true;
    }
}
