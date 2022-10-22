using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BlackHarpyMonsterRace : Base2MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.Black;
        public override string Name => "Black harpy";

        public override bool Animal => true;
        public override int ArmourClass => 22;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 2;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 2;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "A woman's face on the body of a vicious black bird.";
        public override bool Evil => true;
        public override bool Female => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Black harpy";
        public override int Hdice => 3;
        public override int Hside => 8;
        public override int Level => 9;
        public override int Mexp => 19;
        public override int NoticeRange => 16;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Black    ";
        public override string SplitName3 => "   harpy    ";
    }
}
