using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantBlackDragonFlyMonsterRace : MonsterRace
    {
        protected GiantBlackDragonFlyMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheAcidMonsterSpell());
        public override char Character => 'F';
        public override Colour Colour => Colour.Black;
        public override string Name => "Giant black dragon fly";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => null;
        public override bool BashDoor => true;
        public override string Description => "The size of a large bird, this fly drips caustic acid.";
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Giant black dragon fly";
        public override int Hdice => 3;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override int LevelFound => 18;
        public override int Mexp => 68;
        public override bool NeverAttack => true;
        public override int NoticeRange => 12;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 50;
        public override int Speed => 120;
        public override string SplitName1 => "Giant black ";
        public override string SplitName2 => "   dragon   ";
        public override string SplitName3 => "    fly     ";
        public override bool WeirdMind => true;
    }
}
