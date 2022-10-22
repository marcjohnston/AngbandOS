using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BlueIckyThingMonsterRace : Base2MonsterRace
    {
        public override char Character => 'i';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Blue icky thing";

        public override int ArmourClass => 20;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.Poison;
        public override AttackType Attack1Type => AttackType.Crawl;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.EatFood;
        public override AttackType Attack2Type => AttackType.Crawl;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 4;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 4;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Confuse => true;
        public override string Description => "It is a strange, slimy, icky creature, with rudimentary intelligence, but evil cunning. It hungers for food, and you look tasty.";
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Blue icky thing";
        public override int Hdice => 10;
        public override int Hside => 6;
        public override bool ImmunePoison => true;
        public override int Level => 14;
        public override int Mexp => 20;
        public override bool Multiply => true;
        public override int NoticeRange => 15;
        public override bool OpenDoor => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override bool Scare => true;
        public override int Sleep => 20;
        public override int Speed => 100;
        public override string SplitName1 => "    Blue    ";
        public override string SplitName2 => "    icky    ";
        public override string SplitName3 => "   thing    ";
    }
}
