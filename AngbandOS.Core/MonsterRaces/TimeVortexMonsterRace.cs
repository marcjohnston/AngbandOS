namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TimeVortexMonsterRace : MonsterRace
    {
        protected TimeVortexMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheTimeMonsterSpell());
        public override char Character => 'v';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Time vortex";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new EngulfAttackType(), new HurtAttackEffect(), 5, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "You haven't seen it yet.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Time vortex";
        public override int Hdice => 32;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 38;
        public override int Mexp => 900;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool Powerful => true;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override int Sleep => 0;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Time    ";
        public override string SplitName3 => "   vortex   ";
    }
}
