namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GreyWraithMonsterRace : MonsterRace
    {
        protected GreyWraithMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new CauseCriticalWoundsMonsterSpell(),
            new HoldMonsterSpell(),
            new ScareMonsterSpell(),
            new DarknessMonsterSpell());
        public override char Character => 'W';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Grey wraith";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
            new MonsterAttack(new TouchAttackType(), new Exp40AttackEffect(), 0, 0),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A tangible but ghostly form, made of grey fog. The air around it feels deathly cold.";
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "Grey wraith";
        public override int Hdice => 19;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 36;
        public override int Mexp => 700;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Grey    ";
        public override string SplitName3 => "   wraith   ";
        public override bool Undead => true;
    }
}
