using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class RingMimicMonsterRace : Base2MonsterRace
    {
        public override char Character => '=';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Ring mimic";

        public override bool AcidBolt => true;
        public override int ArmourClass => 60;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new PoisonAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new PoisonAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 4;
        public override BaseAttackEffect? Attack3Effect => new PoisonAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 4;
        public override BaseAttackEffect? Attack4Effect => new PoisonAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool Blindness => true;
        public override bool CauseSeriousWounds => true;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override bool ColdBolt => true;
        public override bool Confuse => true;
        public override string Description => "A strange creature that disguises itself as discarded objects to lure unsuspecting adventurers within reach of its venomous claws.";
        public override bool EmptyMind => true;
        public override bool FireBolt => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Ring mimic";
        public override int Hdice => 10;
        public override int Hside => 35;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int Level => 29;
        public override bool LightningBolt => true;
        public override int Mexp => 200;
        public override bool NeverMove => true;
        public override int NoticeRange => 30;
        public override int Rarity => 4;
        public override bool Scare => true;
        public override int Sleep => 100;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Ring    ";
        public override string SplitName3 => "   mimic    ";
        public override bool SummonMonster => true;
    }
}
