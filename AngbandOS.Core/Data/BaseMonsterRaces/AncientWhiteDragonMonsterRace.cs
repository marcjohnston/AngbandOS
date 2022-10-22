using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class AncientWhiteDragonMonsterRace : Base2MonsterRace
    {
        public override char Character => 'D';
        public override string Name => "Ancient white dragon";

        public override int ArmourClass => 90;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 9;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 4;
        public override int Attack2DSides => 9;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 5;
        public override int Attack3DSides => 12;
        public override BaseAttackEffect? Attack3Effect => new ColdAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheCold => true;
        public override bool Confuse => true;
        public override string Description => "A huge draconic form. Frost covers it from head to tail.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Ancient white dragon";
        public override int Hdice => 70;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 39;
        public override int Mexp => 2500;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool Powerful => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 80;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "  Ancient   ";
        public override string SplitName2 => "   white    ";
        public override string SplitName3 => "   dragon   ";
    }
}
