namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class DarkElvenMageMonsterRace : MonsterRace
    {
        protected DarkElvenMageMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new ConfuseMonsterSpell(),
            new MagicMissileMonsterSpell(),
            new PoisonBallMonsterSpell(),
            new DarknessMonsterSpell());
        public override char Character => 'h';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Dark elven mage";

        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A dark elven figure, dressed all in black, hurling spells at you.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Dark elven mage";
        public override int Hdice => 7;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmunePoison => true;
        public override int LevelFound => 10;
        public override int Mexp => 50;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "    Dark    ";
        public override string SplitName2 => "   elven    ";
        public override string SplitName3 => "    mage    ";
    }
}
