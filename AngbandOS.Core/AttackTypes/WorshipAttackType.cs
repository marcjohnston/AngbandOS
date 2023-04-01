namespace AngbandOS.Core.AttackTypes
{
    internal class WorshipAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"hero worships {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => saveGame.SingletonRepository.WorshipPlayerAttacks.ToWeightedRandom().Choose();
        public override string KnowledgeAction => "hero worship";
        public override bool AttackTouchesTarget => false;
    }
}
