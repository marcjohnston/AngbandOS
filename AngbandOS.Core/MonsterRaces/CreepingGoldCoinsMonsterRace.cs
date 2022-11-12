using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class CreepingGoldCoinsMonsterRace : MonsterRace
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Creeping gold coins";

        public override bool Animal => true;
        public override int ArmourClass => 36;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 5),
            new MonsterAttack(AttackType.Touch, new PoisonAttackEffect(), 3, 5),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a pile of coins, crawling forward on thousands of tiny legs.";
        public override bool Drop_1D2 => true;
        public override bool Drop90 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Creeping gold coins";
        public override int Hdice => 18;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 10;
        public override int Mexp => 32;
        public override int NoticeRange => 5;
        public override bool OnlyDropGold => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 100;
        public override string SplitName1 => "  Creeping  ";
        public override string SplitName2 => "    gold    ";
        public override string SplitName3 => "   coins    ";
    }
}
