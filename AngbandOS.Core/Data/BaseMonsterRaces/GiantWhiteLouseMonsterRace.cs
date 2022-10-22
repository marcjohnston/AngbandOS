using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantWhiteLouseMonsterRace : Base2MonsterRace
    {
        public override char Character => 'l';
        public override string Name => "Giant white louse";

        public override bool Animal => true;
        public override int ArmourClass => 5;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 1;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.Nothing;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "It is six inches long.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant white louse";
        public override int Hdice => 1;
        public override int Hside => 1;
        public override int Level => 3;
        public override int Mexp => 1;
        public override bool Multiply => true;
        public override int NoticeRange => 6;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   white    ";
        public override string SplitName3 => "   louse    ";
        public override bool WeirdMind => true;
    }
}
