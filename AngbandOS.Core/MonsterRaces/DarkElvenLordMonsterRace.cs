namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class DarkElvenLordMonsterRace : MonsterRace
    {
        protected DarkElvenLordMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new ColdBoltMonsterSpell(),
            new ConfuseMonsterSpell(),
            new FireBoltMonsterSpell(),
            new MagicMissileMonsterSpell(),
            new DarknessMonsterSpell(),
            new HasteMonsterSpell());
        public override char Character => 'h';
        public override Colour Colour => Colour.BrightPurple;
        public override string Name => "Dark elven lord";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 5),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "A dark elven figure in armour and radiating evil power.";
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Dark elven lord";
        public override int Hdice => 18;
        public override int Hside => 15;
        public override bool HurtByLight => true;
        public override int LevelFound => 20;
        public override bool Male => true;
        public override int Mexp => 500;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "    Dark    ";
        public override string SplitName2 => "   elven    ";
        public override string SplitName3 => "    lord    ";
    }
}
