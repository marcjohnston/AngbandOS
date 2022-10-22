using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class LengSpiderMonsterRace : Base2MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Leng spider";

        public override int ArmourClass => 68;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 3;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 10;
        public override BaseAttackEffect? Attack2Effect => new PoisonAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Cthuloid => true;
        public override string Description => "'There were scenes of old wars, wherein Leng's almost-humans fought with the bloated purple spiders of neighbouring vales.' H.P.Lovecraft - 'The Dream Quest of Unknown Kadath'";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool EldritchHorror => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Leng spider";
        public override bool Haste => true;
        public override int Hdice => 45;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int Level => 33;
        public override int Mexp => 400;
        public override bool MindBlast => true;
        public override bool MoveBody => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 6;
        public override bool Reflecting => true;
        public override bool Scare => true;
        public override int Sleep => 255;
        public override bool Slow => true;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Leng    ";
        public override string SplitName3 => "   spider   ";
        public override bool SummonSpider => true;
        public override bool TakeItem => true;
    }
}
