using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class PotionMimicMonsterRace : Base2MonsterRace
    {
        public override char Character => '!';
        public override string Name => "Potion mimic";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new PoisonAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 3;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 3;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool Blindness => true;
        public override bool CauseSeriousWounds => true;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override bool ColdBolt => true;
        public override bool Confuse => true;
        public override string Description => "A strange creature that disguises itself as discarded objects to lure unsuspecting adventurers within reach of its venomous claws.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Potion mimic";
        public override int Hdice => 10;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int Level => 18;
        public override int Mexp => 60;
        public override bool NeverMove => true;
        public override int NoticeRange => 25;
        public override int Rarity => 3;
        public override bool Scare => true;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Potion   ";
        public override string SplitName3 => "   mimic    ";
    }
}
