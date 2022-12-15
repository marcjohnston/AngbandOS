using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class EnergyVortexMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheLightningMonsterSpell());
        public override char Character => 'v';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Energy vortex";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Engulf, new ElectricityAttackEffect(), 5, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "A shimmering tornado of air, sparks crackle along its length.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Energy vortex";
        public override int Hdice => 12;
        public override int Hside => 12;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneLightning => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 21;
        public override bool LightningAura => true;
        public override int Mexp => 130;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool Powerful => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Energy   ";
        public override string SplitName3 => "   vortex   ";
    }
}
