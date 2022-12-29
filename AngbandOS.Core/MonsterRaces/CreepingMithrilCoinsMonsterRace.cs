using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class CreepingMithrilCoinsMonsterRace : MonsterRace
    {
        protected CreepingMithrilCoinsMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => '$';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Creeping mithril coins";

        public override bool Animal => true;
        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 5),
            new MonsterAttack(new TouchAttackType(), new PoisonAttackEffect(), 3, 5),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a pile of coins, shambling forward on thousands of tiny legs.";
        public override bool Drop_2D2 => true;
        public override bool Drop90 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Creeping mithril coins";
        public override int Hdice => 20;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 13;
        public override int Mexp => 45;
        public override int NoticeRange => 5;
        public override bool OnlyDropGold => true;
        public override int Rarity => 4;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "  Creeping  ";
        public override string SplitName2 => "  mithril   ";
        public override string SplitName3 => "   coins    ";
    }
}
