using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class RockLizardMonsterRace : Base2MonsterRace
    {
        public override char Character => 'R';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Rock lizard";

        public override bool Animal => true;
        public override int ArmourClass => 4;
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
        public override string Description => "It is a small lizard with a hardened hide.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Rock lizard";
        public override int Hdice => 3;
        public override int Hside => 4;
        public override int Level => 1;
        public override int Mexp => 2;
        public override int NoticeRange => 20;
        public override int Rarity => 1;
        public override int Sleep => 15;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Rock    ";
        public override string SplitName3 => "   lizard   ";
    }
}
