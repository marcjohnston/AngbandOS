using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ScrawnyCatMonsterRace : Base2MonsterRace
    {
        public override char Character => 'f';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Scrawny cat";

        public override bool Animal => true;
        public override int ArmourClass => 1;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 1;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => null;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "A skinny little furball with sharp claws and a menacing look.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Scrawny cat";
        public override int Hdice => 1;
        public override int Hside => 2;
        public override int Level => 0;
        public override int Mexp => 0;
        public override int NoticeRange => 30;
        public override bool RandomMove25 => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Scrawny   ";
        public override string SplitName3 => "    cat     ";
    }
}
