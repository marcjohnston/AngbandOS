using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class LargeYellowSnakeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'J';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "Large yellow snake";

        public override bool Animal => true;
        public override int ArmourClass => 38;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "It is about ten feet long.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Large yellow snake";
        public override int Hdice => 4;
        public override int Hside => 8;
        public override int Level => 2;
        public override int Mexp => 9;
        public override int NoticeRange => 5;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 75;
        public override int Speed => 100;
        public override string SplitName1 => "   Large    ";
        public override string SplitName2 => "   yellow   ";
        public override string SplitName3 => "   snake    ";
    }
}
