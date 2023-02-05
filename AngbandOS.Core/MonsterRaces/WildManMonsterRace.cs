namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class WildManMonsterRace : MonsterRace
    {
        protected WildManMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new Arrow1D6MonsterSpell());
        public override char Character => 'h';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Wild man";

        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "Is it a man or an ape? Either way it doesn't seem too friendly. ";
        public override bool Drop60 => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Wild man";
        public override bool Friends => true;
        public override int Hdice => 3;
        public override int Hside => 5;
        public override int LevelFound => 5;
        public override int Mexp => 20;
        public override int NoticeRange => 10;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Wild    ";
        public override string SplitName3 => "    man     ";
    }
}
