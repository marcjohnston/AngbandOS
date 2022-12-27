using AngbandOS.Core.WeightedRandoms;

namespace AngbandOS.Core.AttackTypes
{
    internal class InsultAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"insults {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => new InsultPlayerAttacks().Choose();
        public override string KnowledgeAction => "insult";
        public override bool AttackTouchesTarget => false;
        public override bool AttackAwakensTarget => true;
    }
}
