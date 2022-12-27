using System.Threading;

namespace AngbandOS.Core.AttackTypes
{
    internal class HitAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"hits {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => $"hits you";
        public override string KnowledgeAction => "hit";
        public override bool AttackStunsTarget => true;
        public override bool AttackCutsTarget => true;
    }
}
