namespace AngbandOS.Core.AttackTypes
{
    internal class ClawAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"claws {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => $"claws you";
        public override bool AttackCutsTarget => true;
        public override string KnowledgeAction => "claw";
    }
}
