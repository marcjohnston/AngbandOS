using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BlueYeekMonsterRace : Base2MonsterRace
    {
        public override char Character => 'y';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Blue yeek";

        public override bool Animal => true;
        public override int ArmourClass => 14;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
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
        public override bool BashDoor => true;
        public override string Description => "A small humanoid figure.";
        public override bool Drop60 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Blue yeek";
        public override int Hdice => 2;
        public override int Hside => 6;
        public override bool ImmuneAcid => true;
        public override int Level => 2;
        public override int Mexp => 4;
        public override int NoticeRange => 18;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Blue    ";
        public override string SplitName3 => "    yeek    ";
    }
}
