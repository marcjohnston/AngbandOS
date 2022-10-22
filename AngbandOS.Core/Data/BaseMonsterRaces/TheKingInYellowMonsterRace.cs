using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TheKingInYellowMonsterRace : Base2MonsterRace
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "The King in Yellow";

        public override bool AcidBolt => true;
        public override int ArmourClass => 150;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override AttackEffect Attack1Effect => AttackEffect.Nothing;
        public override AttackType Attack1Type => AttackType.Nothing;
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
        public override bool BreatheCold => true;
        public override bool BreatheFire => true;
        public override bool BreatheNether => true;
        public override bool BreathePoison => true;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "A sentient arcane tome casting spells with malevolent intent.";
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "The King in Yellow";
        public override int Hdice => 50;
        public override int Hside => 15;
        public override bool HurtByFire => true;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 36;
        public override bool ManaBolt => true;
        public override int Mexp => 1500;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 20;
        public override bool PoisonBall => true;
        public override int Rarity => 4;
        public override bool ResistNether => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 15;
        public override int Speed => 120;
        public override string SplitName1 => "    The     ";
        public override string SplitName2 => "  King in   ";
        public override string SplitName3 => "   Yellow   ";
        public override bool WaterBolt => true;
    }
}
