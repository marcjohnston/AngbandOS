using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SasquatchMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Y';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Sasquatch";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 10;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 8;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "A tall shaggy, furry humanoid, it could call the yeti brother.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Sasquatch";
        public override int Hdice => 20;
        public override int Hside => 19;
        public override bool ImmuneCold => true;
        public override int Level => 20;
        public override int Mexp => 180;
        public override int NoticeRange => 15;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Sasquatch  ";
    }
}
