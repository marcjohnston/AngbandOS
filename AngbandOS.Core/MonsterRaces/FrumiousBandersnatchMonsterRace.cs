namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FrumiousBandersnatchMonsterRace : MonsterRace
    {
        protected FrumiousBandersnatchMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'c';
        public override Colour Colour => Colour.BrightOrange;
        public override string Name => "Frumious bandersnatch";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 4),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 4),
            new MonsterAttack(new StingAttackType(), new HurtAttackEffect(), 2, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a vast armoured centipede with massive mandibles and a spiked tail.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Frumious bandersnatch";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override int LevelFound => 12;
        public override int Mexp => 40;
        public override int NoticeRange => 12;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Frumious  ";
        public override string SplitName3 => "bandersnatch";
        public override bool WeirdMind => true;
    }
}
