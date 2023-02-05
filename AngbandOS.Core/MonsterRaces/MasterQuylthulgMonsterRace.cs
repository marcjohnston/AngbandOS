namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MasterQuylthulgMonsterRace : MonsterRace
    {
        protected MasterQuylthulgMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new SummonDragonMonsterSpell(),
            new SummonHiDragonMonsterSpell(),
            new SummonHiUndeadMonsterSpell(),
            new SummonMonsterMonsterSpell(),
            new SummonMonstersMonsterSpell(),
            new SummonUndeadMonsterSpell());
        public override char Character => 'Q';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Master quylthulg";

        public override bool Animal => true;
        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => null;
        public override string Description => "A pulsating mound of flesh, shining with silver pulses of throbbing light.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Master quylthulg";
        public override int Hdice => 20;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 71;
        public override int Mexp => 12000;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 20;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Master   ";
        public override string SplitName3 => " quylthulg  ";
    }
}
