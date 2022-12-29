namespace AngbandOS.Core.AttackTypes
{
    internal class WailAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"wails at {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => $"wails at you";
        public override string KnowledgeAction => "wail";
        public override bool AttackTouchesTarget => false;
    }
}
