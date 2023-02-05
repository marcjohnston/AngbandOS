namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class XarenMonsterRace : MonsterRace
    {
        protected XarenMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'x';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Xaren";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 4),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 4),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 4),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 4)
        };
        public override bool ColdBlood => true;
        public override string Description => "It is a tougher relative of the Xorn. Its hide glitters with metal ores.";
        public override bool EmptyMind => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Xaren";
        public override int Hdice => 32;
        public override int Hside => 10;
        public override bool HurtByRock => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillItem => true;
        public override int LevelFound => 40;
        public override int Mexp => 1200;
        public override int NoticeRange => 20;
        public override bool PassWall => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Xaren    ";
    }
}
