using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ShimmeringVortexMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheLightMonsterSpell(),
            new ShriekMonsterSpell());
        public override char Character => 'v';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Shimmering vortex";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => null;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override string Description => "A strange pillar of shining light that hurts your eyes. Its shape changes constantly as it cuts through the air towards you. It is like a beacon, waking monsters from their slumber.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Shimmering vortex";
        public override int Hdice => 6;
        public override int Hside => 12;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 38;
        public override int Mexp => 200;
        public override bool NeverAttack => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool Powerful => true;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override int Speed => 140;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Shimmering ";
        public override string SplitName3 => "   vortex   ";
    }
}
