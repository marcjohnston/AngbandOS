namespace AngbandOS.Core.AttackTypes
{
    internal class PunchAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"punches {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => $"punches you";
        public override string KnowledgeAction => "punch";
        public override bool AttackStunsTarget => true;
    }
}
