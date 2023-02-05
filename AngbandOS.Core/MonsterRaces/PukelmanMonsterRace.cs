namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class PukelmanMonsterRace : MonsterRace
    {
        protected PukelmanMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new AcidBoltMonsterSpell(),
            new ConfuseMonsterSpell(),
            new SlowMonsterSpell());
        public override char Character => 'g';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Pukelman";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 12),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A stumpy figure carved from stone, with glittering eyes.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Pukelman";
        public override int Hdice => 80;
        public override int Hside => 12;
        public override bool HurtByRock => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 25;
        public override int Mexp => 600;
        public override int NoticeRange => 12;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Pukelman  ";
    }
}
