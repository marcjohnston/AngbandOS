using System.Threading;

namespace AngbandOS.Core.AttackTypes
{
    internal class GazeAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"gazes at {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => $"gazes at you";
        public override string KnowledgeAction => "gaze";
        public override bool AttackTouchesTarget => false;
    }
}
