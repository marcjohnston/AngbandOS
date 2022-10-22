using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class IceElementalMonsterRace : Base2MonsterRace
    {
        public override char Character => 'E';
        public override string Name => "Ice elemental";

        public override int ArmourClass => 60;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override AttackEffect Attack1Effect => AttackEffect.Cold;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 4;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.Cold;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool ColdBall => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a towering glacier of ice.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Ice elemental";
        public override int Hdice => 35;
        public override int Hside => 10;
        public override bool IceBolt => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override int Level => 36;
        public override int Mexp => 650;
        public override int NoticeRange => 10;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override int Sleep => 90;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Ice     ";
        public override string SplitName3 => " elemental  ";
    }
}
