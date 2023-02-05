namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class YoungRedDragonMonsterRace : MonsterRace
    {
        protected YoungRedDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheFireMonsterSpell(),
            new ScareMonsterSpell());
        public override char Character => 'd';
        public override Colour Colour => Colour.Red;
        public override string Name => "Young red dragon";

        public override int ArmourClass => 63;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 8),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 8),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "It has a form that legends are made of. Its still-tender scales are a deepest red hue. Heat radiates from its form.";
        public override bool Dragon => true;
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Young red dragon";
        public override int Hdice => 29;
        public override int Hside => 10;
        public override bool ImmuneFire => true;
        public override int LevelFound => 36;
        public override int Mexp => 640;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "   Young    ";
        public override string SplitName2 => "    red     ";
        public override string SplitName3 => "   dragon   ";
    }
}
