using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class WaterVortexMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheAcidMonsterSpell());
        public override char Character => 'v';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Water vortex";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Engulf, new AcidAttackEffect(), 3, 3),
        };
        public override bool BashDoor => true;
        public override string Description => "A caustic spinning whirlpool of water.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Water vortex";
        public override int Hdice => 9;
        public override int Hside => 9;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 21;
        public override int Mexp => 100;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool Powerful => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Water    ";
        public override string SplitName3 => "   vortex   ";
    }
}
