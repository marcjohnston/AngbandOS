using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class LightHoundMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Light hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.Nothing;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool BreatheLight => true;
        public override string Description => "A brilliant canine form whose light hurts your eyes, even at this distance.";
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Light hound";
        public override bool Friends => true;
        public override int Hdice => 6;
        public override int Hside => 6;
        public override int Level => 15;
        public override int Mexp => 50;
        public override int NoticeRange => 30;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Light    ";
        public override string SplitName3 => "   hound    ";
    }
}
