using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class KillerCrimsonBeetleMonsterRace : Base2MonsterRace
    {
        public override char Character => 'K';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Killer crimson beetle";

        public override bool Animal => true;
        public override int ArmourClass => 50;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.LoseStr;
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
        public override string Description => "A giant beetle with poisonous mandibles.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Killer crimson beetle";
        public override int Hdice => 20;
        public override int Hside => 8;
        public override int Level => 25;
        public override int Mexp => 85;
        public override int NoticeRange => 14;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "   Killer   ";
        public override string SplitName2 => "  crimson   ";
        public override string SplitName3 => "   beetle   ";
        public override bool WeirdMind => true;
    }
}
