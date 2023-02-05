namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BlackWraithMonsterRace : MonsterRace
    {
        protected BlackWraithMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new CauseCriticalWoundsMonsterSpell(),
            new HoldMonsterSpell(),
            new NetherBoltMonsterSpell(),
            new ScareMonsterSpell());
        public override char Character => 'W';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Black wraith";

        public override int ArmourClass => 55;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 12),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 12),
            new MonsterAttack(new TouchAttackType(), new Exp40AttackEffect(), 0, 0),
            new MonsterAttack(new TouchAttackType(), new Exp40AttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A figure that seems made of void, its strangely human shape is cloaked in shadow. It reaches out at you.";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "Black wraith";
        public override int Hdice => 50;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 38;
        public override int Mexp => 1700;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Black    ";
        public override string SplitName3 => "   wraith   ";
        public override bool Undead => true;
    }
}
