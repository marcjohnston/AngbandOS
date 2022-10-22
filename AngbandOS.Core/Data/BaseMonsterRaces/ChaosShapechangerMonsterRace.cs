using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ChaosShapechangerMonsterRace : Base2MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Chaos shapechanger";

        public override int ArmourClass => 14;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 5;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.Confuse;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool ColdBolt => true;
        public override bool Confuse => true;
        public override string Description => "A vaguely humanoid form constantly changing its appearance.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Chaos shapechanger";
        public override int Hdice => 20;
        public override int Hside => 9;
        public override int Level => 11;
        public override int Mexp => 38;
        public override int NoticeRange => 10;
        public override int Rarity => 2;
        public override bool Shapechanger => true;
        public override int Sleep => 12;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Chaos    ";
        public override string SplitName3 => "shapechanger";
    }
}
