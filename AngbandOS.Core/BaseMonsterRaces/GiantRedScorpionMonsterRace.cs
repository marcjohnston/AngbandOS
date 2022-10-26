using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantRedScorpionMonsterRace : Base2MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Giant red scorpion";

        public override bool Animal => true;
        public override int ArmourClass => 44;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 4),
            new MonsterAttack(AttackType.Sting, new LoseStrAttackEffect(), 1, 7),
        };
        public override bool BashDoor => true;
        public override string Description => "It is fast and poisonous.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant red scorpion";
        public override int Hdice => 11;
        public override int Hside => 8;
        public override int Level => 17;
        public override int Mexp => 62;
        public override int NoticeRange => 12;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "    red     ";
        public override string SplitName3 => "  scorpion  ";
        public override bool WeirdMind => true;
    }
}
