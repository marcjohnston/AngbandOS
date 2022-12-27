using AngbandOS.Core.WeightedRandoms;

namespace AngbandOS.Core.AttackTypes
{
    internal class MoanAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"moans at {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => new MoanPlayerAttacks().Choose();
        public override string KnowledgeAction => "moan";
        public override bool AttackAwakensTarget => true;
    }
}
