using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class AncientRedDragonMonsterRace : Base2MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.Red;
        public override string Name => "Ancient red dragon";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 4;
        public override int Attack2DSides => 10;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 5;
        public override int Attack3DSides => 14;
        public override AttackEffect Attack3Effect => AttackEffect.Fire;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheFire => true;
        public override bool Confuse => true;
        public override string Description => "A huge draconic form. Wisps of smoke steam from its nostrils and the extreme heat surrounding it makes you gasp for breath.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Ancient red dragon";
        public override int Hdice => 10;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int Level => 40;
        public override int Mexp => 2750;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool Powerful => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 70;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "  Ancient   ";
        public override string SplitName2 => "    red     ";
        public override string SplitName3 => "   dragon   ";
    }
}
