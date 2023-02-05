namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class HandDrujMonsterRace : MonsterRace
    {
        protected HandDrujMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new CauseCriticalWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new ScareMonsterSpell(),
            new DarknessMonsterSpell(),
            new ForgetMonsterSpell(),
            new TeleportAwayMonsterSpell());
        public override char Character => 's';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Hand druj";

        public override int ArmourClass => 110;
        public override MonsterAttack[]? Attacks => null;
        public override bool ColdBlood => true;
        public override string Description => "A skeletal hand floating in the air, motionless except for its flexing fingers.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 1;
        public override int FreqSpell => 1;
        public override string FriendlyName => "Hand druj";
        public override int Hdice => 60;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 55;
        public override int Mexp => 12000;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 20;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Hand    ";
        public override string SplitName3 => "    druj    ";
        public override bool Undead => true;
    }
}
