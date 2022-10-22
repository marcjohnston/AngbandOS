using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class OrfaxSonOfBoldorMonsterRace : Base2MonsterRace
    {
        public override char Character => 'y';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Orfax, Son of Boldor";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 9;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 8;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Insult;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Insult;
        public override bool BashDoor => true;
        public override bool Blink => true;
        public override bool Confuse => true;
        public override string Description => "He's just like daddy! He knows mighty spells, but fortunately he is a yeek.";
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Orfax, Son of Boldor";
        public override int Hdice => 12;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override int Level => 10;
        public override bool Male => true;
        public override int Mexp => 80;
        public override int NoticeRange => 18;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Orfax    ";
        public override bool SummonMonster => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
    }
}
