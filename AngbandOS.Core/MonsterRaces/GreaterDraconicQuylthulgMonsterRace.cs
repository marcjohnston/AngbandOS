namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GreaterDraconicQuylthulgMonsterRace : MonsterRace
    {
        protected GreaterDraconicQuylthulgMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlinkMonsterSpell(),
            new SummonHiDragonMonsterSpell(),
            new TeleportToMonsterSpell());
        public override char Character => 'Q';
        public override Colour Colour => Colour.Green;
        public override string Name => "Greater draconic quylthulg";

        public override bool Animal => true;
        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => null;
        public override string Description => "A massive mound of scaled flesh, throbbing and pulsating with multi-hued light.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Greater draconic quylthulg";
        public override int Hdice => 15;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 71;
        public override int Mexp => 10500;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 20;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "  Greater   ";
        public override string SplitName2 => "  draconic  ";
        public override string SplitName3 => " quylthulg  ";
    }
}
