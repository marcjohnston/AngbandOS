using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GridBugMonsterRace : Base2MonsterRace
    {
        public override char Character => 'I';
        public override Colour Colour => Colour.BrightPurple;
        public override string Name => "Grid bug";

        public override bool Animal => true;
        public override int ArmourClass => 2;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new ElectricityAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
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
        public override string Description => "A strange electric bug.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Grid bug";
        public override bool Friends => true;
        public override int Hdice => 2;
        public override int Hside => 4;
        public override bool ImmuneFear => true;
        public override bool ImmuneLightning => true;
        public override int Level => 1;
        public override int Mexp => 2;
        public override int NoticeRange => 10;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Grid    ";
        public override string SplitName3 => "    bug     ";
        public override bool Stupid => true;
        public override bool WeirdMind => true;
    }
}
