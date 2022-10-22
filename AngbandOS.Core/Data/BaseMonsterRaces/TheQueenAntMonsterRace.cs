using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TheQueenAntMonsterRace : Base2MonsterRace
    {
        public override char Character => 'a';
        public override Colour Colour => Colour.Gold;
        public override string Name => "The Queen Ant";

        public override bool Animal => true;
        public override int ArmourClass => 100;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 12;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 8;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 8;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override string Description => "She's upset because you hurt her children.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "The Queen Ant";
        public override bool Good => true;
        public override int Hdice => 15;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 37;
        public override int Mexp => 1000;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "    The     ";
        public override string SplitName2 => "   Queen    ";
        public override string SplitName3 => "    Ant     ";
        public override bool SummonAnt => true;
        public override bool Unique => true;
        public override bool WeirdMind => true;
    }
}
