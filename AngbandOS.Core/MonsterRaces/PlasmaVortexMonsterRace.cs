using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class PlasmaVortexMonsterRace : MonsterRace
    {
        public override char Character => 'v';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Plasma vortex";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Engulf, new FireAttackEffect(), 8, 8),
        };
        public override bool BashDoor => true;
        public override bool BreathePlasma => true;
        public override string Description => "A whirlpool of intense flame, charring the stones at your feet.";
        public override bool EmptyMind => true;
        public override bool FireAura => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Plasma vortex";
        public override int Hdice => 32;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 37;
        public override bool LightningAura => true;
        public override int Mexp => 800;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool Powerful => true;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override bool ResistPlasma => true;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Plasma   ";
        public override string SplitName3 => "   vortex   ";
    }
}
