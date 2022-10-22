using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class KillerSlicerBeetleMonsterRace : Base2MonsterRace
    {
        public override char Character => 'K';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Killer slicer beetle";

        public override bool Animal => true;
        public override int ArmourClass => 60;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 8;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 8;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "It is a beetle with deadly sharp cutting mandibles and a rock-hard carapace.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Killer slicer beetle";
        public override int Hdice => 22;
        public override int Hside => 10;
        public override int Level => 30;
        public override int Mexp => 200;
        public override int NoticeRange => 14;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "   Killer   ";
        public override string SplitName2 => "   slicer   ";
        public override string SplitName3 => "   beetle   ";
        public override bool WeirdMind => true;
    }
}
