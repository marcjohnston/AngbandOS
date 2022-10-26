using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GreatWyrmOfLawMonsterRace : Base2MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.Silver;
        public override string Name => "Great Wyrm of Law";

        public override int ArmourClass => 170;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 5, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 5, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 5, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 8, 14)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheShards => true;
        public override bool BreatheSound => true;
        public override bool Confuse => true;
        public override string Description => "A massive dragon of powerful intellect. It seeks to dominate the universe and despises all other life. It sees all who do not obey it as mere insects to be crushed underfoot.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Great Wyrm of Law";
        public override bool Good => true;
        public override int Hdice => 45;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 67;
        public override int Mexp => 29000;
        public override bool MoveBody => true;
        public override int NoticeRange => 40;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 255;
        public override int Speed => 120;
        public override string SplitName1 => "   Great    ";
        public override string SplitName2 => "  Wyrm of   ";
        public override string SplitName3 => "    Law     ";
        public override bool SummonDragon => true;
    }
}
