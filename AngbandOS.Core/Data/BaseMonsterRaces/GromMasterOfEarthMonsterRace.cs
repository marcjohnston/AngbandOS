using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GromMasterOfEarthMonsterRace : Base2MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Grom, Master of Earth";

        public override bool AcidBall => true;
        public override bool AcidBolt => true;
        public override int ArmourClass => 97;
        public override int Attack1DDice => 6;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 6;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 6;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 10;
        public override int Attack4DSides => 10;
        public override AttackEffect Attack4Effect => AttackEffect.Shatter;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool ColdBlood => true;
        public override string Description => "A towering stone elemental stands before you. The walls and ceiling are reduced to rubble as Grom advances.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Grom, Master of Earth";
        public override int Hdice => 18;
        public override int Hside => 100;
        public override bool HurtByRock => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override bool KillWall => true;
        public override int Level => 43;
        public override bool Male => true;
        public override int Mexp => 6000;
        public override int NoticeRange => 10;
        public override bool PassWall => true;
        public override bool Powerful => true;
        public override int Rarity => 4;
        public override int Sleep => 90;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Grom    ";
        public override bool Unique => true;
    }
}
