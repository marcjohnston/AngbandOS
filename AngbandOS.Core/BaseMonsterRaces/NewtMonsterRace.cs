using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class NewtMonsterRace : Base2MonsterRace
    {
        public override char Character => 'R';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Newt";

        public override bool Animal => true;
        public override int ArmourClass => 12;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 3),
        };
        public override string Description => "A small, harmless lizard.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Newt";
        public override int Hdice => 2;
        public override int Hside => 6;
        public override int Level => 1;
        public override int Mexp => 2;
        public override int NoticeRange => 8;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Newt    ";
        public override bool WeirdMind => true;
    }
}
