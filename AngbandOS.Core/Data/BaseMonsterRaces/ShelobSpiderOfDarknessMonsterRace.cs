using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ShelobSpiderOfDarknessMonsterRace : Base2MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.Black;
        public override string Name => "Shelob, Spider of Darkness";

        public override bool Animal => true;
        public override int ArmourClass => 80;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 5;
        public override AttackEffect Attack2Effect => AttackEffect.Poison;
        public override AttackType Attack2Type => AttackType.Sting;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 4;
        public override AttackEffect Attack3Effect => AttackEffect.LoseStr;
        public override AttackType Attack3Type => AttackType.Sting;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 5;
        public override AttackEffect Attack4Effect => AttackEffect.Poison;
        public override AttackType Attack4Type => AttackType.Sting;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheDark => true;
        public override bool CauseCriticalWounds => true;
        public override bool CauseMortalWounds => true;
        public override bool Confuse => true;
        public override bool CreateTraps => true;
        public override string Description => "Shelob is an enormous bloated spider, rumoured to have been one of the brood of Ungoliant the Unlight. Her poison is legendary, as is her ego, which may be her downfall. She used to guard the pass through Cirith Ungol, but has not been seen there for many eons.";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Shelob, Spider of Darkness";
        public override int Hdice => 12;
        public override bool Heal => true;
        public override int Hside => 100;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 32;
        public override int Mexp => 1200;
        public override int NoticeRange => 8;
        public override bool OnlyDropItem => true;
        public override int Rarity => 3;
        public override bool Scare => true;
        public override int Sleep => 80;
        public override bool Slow => true;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Shelob   ";
        public override bool SummonSpider => true;
        public override bool Unique => true;
    }
}
