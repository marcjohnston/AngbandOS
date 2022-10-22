using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ApprenticeWarriorMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Apprentice warrior";

        public override int ArmourClass => 16;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 7;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 6;
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
        public override string Description => "He looks inexperienced but tough.";
        public override bool Drop60 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Apprentice warrior";
        public override bool Friends => true;
        public override int Hdice => 9;
        public override int Hside => 4;
        public override int Level => 6;
        public override bool Male => true;
        public override int Mexp => 6;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 5;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "Apprentice";
        public override string SplitName3 => "  warrior   ";
    }
}
