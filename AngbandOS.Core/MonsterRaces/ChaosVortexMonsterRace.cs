using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ChaosVortexMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheChaosMonsterSpell());
        public override char Character => 'v';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Chaos vortex";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => null;
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override string Description => "Void, nothingness, spinning destructively.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Chaos vortex";
        public override int Hdice => 32;
        public override int Hside => 20;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 55;
        public override int Mexp => 4000;
        public override bool NeverAttack => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool Powerful => true;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 140;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Chaos    ";
        public override string SplitName3 => "   vortex   ";
    }
}
