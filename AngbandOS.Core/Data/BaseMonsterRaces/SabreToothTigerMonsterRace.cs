using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SabreToothTigerMonsterRace : Base2MonsterRace
    {
        public override char Character => 'f';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Sabre-tooth tiger";

        public override bool Animal => true;
        public override int ArmourClass => 50;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 10;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 10;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 10;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override string Description => "A fierce and dangerous cat, its huge tusks and sharp claws would lacerate even the strongest armour.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Sabre-tooth tiger";
        public override int Hdice => 20;
        public override int Hside => 14;
        public override int Level => 20;
        public override int Mexp => 120;
        public override int NoticeRange => 40;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "Sabre-tooth ";
        public override string SplitName3 => "   tiger    ";
    }
}
