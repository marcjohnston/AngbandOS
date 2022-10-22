using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class CloudGiantMonsterRace : Base2MonsterRace
    {
        public override char Character => 'P';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Cloud giant";

        public override int ArmourClass => 60;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 8;
        public override AttackEffect Attack1Effect => AttackEffect.Electricity;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 8;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "It is a twenty foot tall giant wreathed in clouds.";
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Cloud giant";
        public override bool Giant => true;
        public override int Hdice => 24;
        public override int Hside => 10;
        public override bool ImmuneLightning => true;
        public override int Level => 20;
        public override bool Male => true;
        public override int Mexp => 125;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Cloud    ";
        public override string SplitName3 => "   giant    ";
        public override bool TakeItem => true;
    }
}
