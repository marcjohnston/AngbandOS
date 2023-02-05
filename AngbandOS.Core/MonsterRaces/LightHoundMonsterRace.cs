namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class LightHoundMonsterRace : MonsterRace
    {
        protected LightHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheLightMonsterSpell());
        public override char Character => 'Z';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Light hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A brilliant canine form whose light hurts your eyes, even at this distance.";
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Light hound";
        public override bool Friends => true;
        public override int Hdice => 6;
        public override int Hside => 6;
        public override int LevelFound => 15;
        public override int Mexp => 50;
        public override int NoticeRange => 30;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Light    ";
        public override string SplitName3 => "   hound    ";
    }
}
