namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TwoHeadedHydraMonsterRace : MonsterRace
    {
        protected TwoHeadedHydraMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ScareMonsterSpell());
        public override char Character => 'M';
        public override Colour Colour => Colour.BrightChartreuse;
        public override string Name => "2-headed hydra";

        public override bool Animal => true;
        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A strange reptilian hybrid with two heads, guarding its hoard.";
        public override bool Drop_1D2 => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "2-headed hydra";
        public override int Hdice => 100;
        public override int Hside => 3;
        public override int LevelFound => 17;
        public override int Mexp => 80;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  2-headed  ";
        public override string SplitName3 => "   hydra    ";
    }
}
