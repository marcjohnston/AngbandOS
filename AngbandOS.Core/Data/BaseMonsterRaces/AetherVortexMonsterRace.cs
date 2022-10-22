using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class AetherVortexMonsterRace : Base2MonsterRace
    {
        public override char Character => 'v';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Aether vortex";

        public override int ArmourClass => 40;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Electricity;
        public override AttackType Attack1Type => AttackType.Engulf;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 3;
        public override AttackEffect Attack2Effect => AttackEffect.Fire;
        public override AttackType Attack2Type => AttackType.Engulf;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.Acid;
        public override AttackType Attack3Type => AttackType.Engulf;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 3;
        public override AttackEffect Attack4Effect => AttackEffect.Cold;
        public override AttackType Attack4Type => AttackType.Engulf;
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool BreatheAcid => true;
        public override bool BreatheChaos => true;
        public override bool BreatheCold => true;
        public override bool BreatheConfusion => true;
        public override bool BreatheDark => true;
        public override bool BreatheFire => true;
        public override bool BreatheForce => true;
        public override bool BreatheGravity => true;
        public override bool BreatheInertia => true;
        public override bool BreatheLight => true;
        public override bool BreatheLightning => true;
        public override bool BreatheNether => true;
        public override bool BreatheNexus => true;
        public override bool BreathePlasma => true;
        public override bool BreathePoison => true;
        public override bool BreatheShards => true;
        public override bool BreatheSound => true;
        public override bool BreatheTime => true;
        public override string Description => "An awesome vortex of pure magic, power radiates from its frame.";
        public override bool EmptyMind => true;
        public override bool FireAura => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Aether vortex";
        public override int Hdice => 32;
        public override int Hside => 20;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 55;
        public override bool LightningAura => true;
        public override int Mexp => 4500;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool Powerful => true;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override bool ResistNether => true;
        public override bool ResistNexus => true;
        public override bool ResistPlasma => true;
        public override int Sleep => 0;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Aether   ";
        public override string SplitName3 => "   vortex   ";
    }
}
