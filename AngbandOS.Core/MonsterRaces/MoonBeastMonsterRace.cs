namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MoonBeastMonsterRace : MonsterRace
    {
        protected MoonBeastMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new CauseSeriousWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DarknessMonsterSpell(),
            new HealMonsterSpell());
        public override char Character => 'A';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Moon beast";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 3),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 3),
            new MonsterAttack(new ButtAttackType(), new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A great greyish-white slippery toad-creature with a mass of pink tentacles on the end of its snout.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Moon beast";
        public override int Hdice => 9;
        public override int Hside => 10;
        public override bool ImmuneFire => true;
        public override int LevelFound => 12;
        public override int Mexp => 57;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Moon    ";
        public override string SplitName3 => "   beast    ";
    }
}
