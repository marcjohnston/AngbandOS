using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class CopperheadSnakeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'J';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Copperhead snake";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.Poison;
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
        public override bool BashDoor => true;
        public override string Description => "It has a copper head and sharp venomous fangs.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Copperhead snake";
        public override int Hdice => 4;
        public override int Hside => 6;
        public override bool ImmunePoison => true;
        public override int Level => 5;
        public override int Mexp => 15;
        public override int NoticeRange => 6;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 1;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Copperhead ";
        public override string SplitName3 => "   snake    ";
    }
}
