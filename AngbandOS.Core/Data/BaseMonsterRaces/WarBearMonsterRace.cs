using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class WarBearMonsterRace : Base2MonsterRace
    {
        public override char Character => 'q';
        public override Colour Colour => Colour.Brown;
        public override string Name => "War bear";

        public override bool Animal => true;
        public override int ArmourClass => 35;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 4;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "Bears with tusks, trained to kill.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "War bear";
        public override bool Friends => true;
        public override int Hdice => 10;
        public override int Hside => 10;
        public override int Level => 9;
        public override int Mexp => 25;
        public override int NoticeRange => 10;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    War     ";
        public override string SplitName3 => "    bear    ";
        public override bool WeirdMind => true;
    }
}
