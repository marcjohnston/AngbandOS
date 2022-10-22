using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ChaosMasterMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Chaos master";

        public override int ArmourClass => 50;
        public override int Attack1DDice => 10;
        public override int Attack1DSides => 2;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 10;
        public override int Attack2DSides => 2;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Kick;
        public override int Attack3DDice => 10;
        public override int Attack3DSides => 2;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Punch;
        public override int Attack4DDice => 10;
        public override int Attack4DSides => 2;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Kick;
        public override bool AttrAny => true;
        public override bool BashDoor => true;
        public override bool ChaosBall => true;
        public override string Description => "An adept of chaos, feared for his skill of invoking raw chaos.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Chaos master";
        public override int Hdice => 30;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 33;
        public override bool Male => true;
        public override int Mexp => 550;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 5;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Chaos    ";
        public override string SplitName3 => "   master   ";
        public override bool SummonDemon => true;
        public override bool SummonSpider => true;
    }
}
