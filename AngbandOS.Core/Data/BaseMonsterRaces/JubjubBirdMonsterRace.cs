using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class JubjubBirdMonsterRace : Base2MonsterRace
    {
        public override char Character => 'B';
        public override Colour Colour => Colour.Pink;
        public override string Name => "Jubjub bird";

        public override bool Animal => true;
        public override int ArmourClass => 70;
        public override int Attack1DDice => 8;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Crush;
        public override int Attack2DDice => 8;
        public override int Attack2DSides => 12;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Crush;
        public override int Attack3DDice => 12;
        public override int Attack3DSides => 12;
        public override AttackEffect Attack3Effect => AttackEffect.Electricity;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "A vast legendary bird, its iron talons rake the most impenetrable of surfaces and its screech echoes through the many winding dungeon corridors.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Jubjub bird";
        public override int Hdice => 80;
        public override int Hside => 13;
        public override bool ImmuneLightning => true;
        public override int Level => 40;
        public override int Mexp => 1000;
        public override int NoticeRange => 20;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Jubjub   ";
        public override string SplitName3 => "    bird    ";
    }
}
