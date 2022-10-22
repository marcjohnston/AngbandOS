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
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.Poison;
        public override AttackType Attack1Type => AttackType.Sting;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 4;
        public override AttackEffect Attack2Effect => AttackEffect.LoseStr;
        public override AttackType Attack2Type => AttackType.Sting;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
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
