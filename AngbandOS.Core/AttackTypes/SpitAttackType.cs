using System.Threading;

namespace AngbandOS.Core.AttackTypes
{
    internal class SpitAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"spits on {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => $"spits on you";
        public override string KnowledgeAction => "spit";

        public override bool AttackTouchesTarget => false;
    }
}
