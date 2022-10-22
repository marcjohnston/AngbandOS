using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class UglukTheUrukMonsterRace : Base2MonsterRace
    {
        public override char Character => 'o';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Ugluk, the Uruk";

        public override int ArmourClass => 90;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 5;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 5;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 5;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override string Description => "Another of Morgoth's servants, this orc is strong and cunning. He is ugly and scarred from many power struggles.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Ugluk, the Uruk";
        public override int Hdice => 64;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int Level => 20;
        public override bool Male => true;
        public override int Mexp => 550;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 4;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Ugluk    ";
        public override bool Unique => true;
    }
}
