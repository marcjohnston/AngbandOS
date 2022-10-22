using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FireGiantMonsterRace : Base2MonsterRace
    {
        public override char Character => 'P';
        public override Colour Colour => Colour.Red;
        public override string Name => "Fire giant";

        public override int ArmourClass => 60;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 7;
        public override AttackEffect Attack1Effect => AttackEffect.Fire;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 7;
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
        public override string Description => "A glowing fourteen foot tall giant. Flames drip from its red skin.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Fire giant";
        public override bool Giant => true;
        public override int Hdice => 20;
        public override int Hside => 8;
        public override bool ImmuneFire => true;
        public override int Level => 16;
        public override bool Male => true;
        public override int Mexp => 54;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Fire    ";
        public override string SplitName3 => "   giant    ";
    }
}
