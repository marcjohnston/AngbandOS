using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class KillerBeeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'I';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "Killer bee";

        public override bool Animal => true;
        public override int ArmourClass => 34;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Sting, new PoisonAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Sting, new LoseStrAttackEffect(), 1, 4),
        };
        public override string Description => "It is poisonous and aggressive.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Killer bee";
        public override bool Friends => true;
        public override int Hdice => 2;
        public override int Hside => 4;
        public override int Level => 9;
        public override int Mexp => 22;
        public override int NoticeRange => 12;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Killer   ";
        public override string SplitName3 => "    bee     ";
        public override bool WeirdMind => true;
    }
}
