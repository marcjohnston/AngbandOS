using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GreatWyrmOfPowerMonsterRace : Base2MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Great Wyrm of Power";

        public override int ArmourClass => 111;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new PoisonAttackEffect(), 8, 12),
            new MonsterAttack(AttackType.Crush, new FireAttackEffect(), 8, 12),
            new MonsterAttack(AttackType.Crush, new ElectricityAttackEffect(), 8, 12),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 10, 18)
        };
        public override bool BashDoor => true;
        public override bool BreatheAcid => true;
        public override bool BreatheChaos => true;
        public override bool BreatheCold => true;
        public override bool BreatheConfusion => true;
        public override bool BreatheDark => true;
        public override bool BreatheDisenchant => true;
        public override bool BreatheDisintegration => true;
        public override bool BreatheFire => true;
        public override bool BreatheForce => true;
        public override bool BreatheGravity => true;
        public override bool BreatheInertia => true;
        public override bool BreatheLight => true;
        public override bool BreatheLightning => true;
        public override bool BreatheMana => true;
        public override bool BreatheNether => true;
        public override bool BreatheNexus => true;
        public override bool BreathePlasma => true;
        public override bool BreathePoison => true;
        public override bool BreatheRadiation => true;
        public override bool BreatheShards => true;
        public override bool BreatheSound => true;
        public override bool BreatheTime => true;
        public override string Description => "The mightiest of all dragonkind, a great wyrm of power is seldom encountered in our world. It can crush stars with its might.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Great Wyrm of Power";
        public override bool Good => true;
        public override int Hdice => 111;
        public override int Hside => 111;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 90;
        public override bool LightningAura => true;
        public override int Mexp => 47500;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 4;
        public override bool Reflecting => true;
        public override bool ResistDisenchant => true;
        public override bool ResistNether => true;
        public override bool ResistNexus => true;
        public override bool ResistPlasma => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 70;
        public override int Speed => 130;
        public override string SplitName1 => "   Great    ";
        public override string SplitName2 => "  Wyrm of   ";
        public override string SplitName3 => "   Power    ";
        public override bool SummonDragon => true;
        public override bool SummonHiDragon => true;
        public override bool SummonKin => true;
    }
}
