using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TimeElementalMonsterRace : Base2MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Time elemental";

        public override int ArmourClass => 70;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.LoseAll;
        public override AttackType Attack1Type => AttackType.Touch;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 4;
        public override AttackEffect Attack2Effect => AttackEffect.Exp40;
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 4;
        public override AttackEffect Attack3Effect => AttackEffect.LoseAll;
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 4;
        public override AttackEffect Attack4Effect => AttackEffect.Exp40;
        public override AttackType Attack4Type => AttackType.Touch;
        public override bool BreatheTime => true;
        public override string Description => "You have not seen it yet.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "Time elemental";
        public override int Hdice => 35;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillItem => true;
        public override int Level => 37;
        public override int Mexp => 1000;
        public override bool Nonliving => true;
        public override int NoticeRange => 90;
        public override bool PassWall => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Time    ";
        public override string SplitName3 => " elemental  ";
    }
}
