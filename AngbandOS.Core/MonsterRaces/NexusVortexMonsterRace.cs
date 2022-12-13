using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NexusVortexMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheNexusMonsterSpell());
        public override char Character => 'v';
        public override Colour Colour => Colour.Pink;
        public override string Name => "Nexus vortex";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Engulf, new HurtAttackEffect(), 5, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "A maelstrom of potent magical energy.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Nexus vortex";
        public override int Hdice => 32;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 37;
        public override int Mexp => 800;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool Powerful => true;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override bool ResistNexus => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Nexus    ";
        public override string SplitName3 => "   vortex   ";
    }
}
