using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantSpiderMonsterRace : Base2MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Giant spider";

        public override bool Animal => true;
        public override int ArmourClass => 16;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Poison;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.Poison;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 10;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override string Description => "It is a vast black spider whose bulbous body is bloated with poison.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant spider";
        public override int Hdice => 10;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int Level => 10;
        public override int Mexp => 35;
        public override int NoticeRange => 8;
        public override int Rarity => 2;
        public override int Sleep => 80;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Giant    ";
        public override string SplitName3 => "   spider   ";
        public override bool WeirdMind => true;
    }
}
