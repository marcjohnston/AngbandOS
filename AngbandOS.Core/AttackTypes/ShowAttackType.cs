namespace AngbandOS.Core.AttackTypes
{
    internal class ShowAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"sings to {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => new SingingPlayerAttacks().Choose();
        public override string KnowledgeAction => "sing";
        public override bool AttackTouchesTarget => false;
        public override bool AttackAwakensTarget => true;
    }
}
