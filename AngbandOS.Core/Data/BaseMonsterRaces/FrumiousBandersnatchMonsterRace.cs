using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FrumiousBandersnatchMonsterRace : Base2MonsterRace
    {
        public override char Character => 'c';
        public override Colour Colour => Colour.BrightOrange;
        public override string Name => "Frumious bandersnatch";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 4;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 4;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Sting;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "It is a vast armoured centipede with massive mandibles and a spiked tail.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Frumious bandersnatch";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override int Level => 12;
        public override int Mexp => 40;
        public override int NoticeRange => 12;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Frumious  ";
        public override string SplitName3 => "bandersnatch";
        public override bool WeirdMind => true;
    }
}
