using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class PukelmanMonsterRace : Base2MonsterRace
    {
        public override char Character => 'g';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Pukelman";

        public override bool AcidBolt => true;
        public override int ArmourClass => 80;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 12;
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
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override string Description => "A stumpy figure carved from stone, with glittering eyes.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Pukelman";
        public override int Hdice => 80;
        public override int Hside => 12;
        public override bool HurtByRock => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 25;
        public override int Mexp => 600;
        public override int NoticeRange => 12;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Pukelman  ";
    }
}
