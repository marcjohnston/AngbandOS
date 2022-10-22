using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ImpactHoundMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Impact hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 12;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 12;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 3;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Claw;
        public override bool BashDoor => true;
        public override bool BreatheForce => true;
        public override string Description => "A deep brown shape is visible before you, its canine form strikes you with an almost physical force. The dungeon floor buckles as if struck by a powerful Attack as it stalks towards you.";
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Impact hound";
        public override bool Friends => true;
        public override int Hdice => 35;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 35;
        public override int Mexp => 500;
        public override int NoticeRange => 30;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Impact   ";
        public override string SplitName3 => "   hound    ";
    }
}
