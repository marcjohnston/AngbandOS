using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FirePhantomMonsterRace : Base2MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Fire Phantom";

        public override int ArmourClass => 90;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
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
        public override bool BreatheFire => true;
        public override bool Confuse => true;
        public override string Description => "He's back from the grave for vengeance on those whoburnt him. He has no mercy for those in his way.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Fire Phantom";
        public override int Hdice => 10;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 34;
        public override bool Male => true;
        public override int Mexp => 1200;
        public override bool MindBlast => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PassWall => true;
        public override int Rarity => 5;
        public override bool Regenerate => true;
        public override bool Scare => true;
        public override int Sleep => 40;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Fire    ";
        public override string SplitName3 => "  Phantom   ";
        public override bool TakeItem => true;
        public override bool Undead => true;
        public override bool Unique => true;
    }
}
