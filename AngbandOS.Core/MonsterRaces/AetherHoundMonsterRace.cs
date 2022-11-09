using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class AetherHoundMonsterRace : MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Aether hound";

        public override bool Animal => true;
        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3)
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool BreatheAcid => true;
        public override bool BreatheChaos => true;
        public override bool BreatheCold => true;
        public override bool BreatheConfusion => true;
        public override bool BreatheDark => true;
        public override bool BreatheDisenchant => true;
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
        public override string Description => "A shifting, swirling form. It seems to be all colours and sizes and shapes, though the dominant form is that of a huge dog. You feel very uncertain all of a sudden.";
        public override bool FireAura => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Aether hound";
        public override bool Friends => true;
        public override int Hdice => 60;
        public override int Hside => 30;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 75;
        public override bool LightningAura => true;
        public override int Mexp => 10000;
        public override int NoticeRange => 30;
        public override int Rarity => 2;
        public override bool ResistDisenchant => true;
        public override bool ResistNether => true;
        public override bool ResistNexus => true;
        public override bool ResistPlasma => true;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Aether   ";
        public override string SplitName3 => "   hound    ";
    }
}
