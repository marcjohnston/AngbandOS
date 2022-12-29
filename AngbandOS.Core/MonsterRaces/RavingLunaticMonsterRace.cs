namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class RavingLunaticMonsterRace : MonsterRace
    {
        protected RavingLunaticMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 't';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Raving lunatic";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new DroolAttackType(), null, 0, 0),
        };
        public override string Description => "Drooling and comical, but then, what do you expect?";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Raving lunatic";
        public override int Hdice => 4;
        public override int Hside => 4;
        public override int LevelFound => 0;
        public override bool Male => true;
        public override int Mexp => 0;
        public override int NoticeRange => 6;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Raving   ";
        public override string SplitName3 => "  lunatic   ";
        public override bool TakeItem => true;
    }
}
