namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BastGoddessOfCatsMonsterRace : MonsterRace
    {
        protected BastGoddessOfCatsMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new HealMonsterSpell(),
            new SummonKinMonsterSpell(),
            new TeleportToMonsterSpell());
        public override char Character => 'f';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Bast, Goddess of Cats";

        public override int ArmourClass => 200;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new ConfuseAttackEffect(), 12, 12),
            new MonsterAttack(new TouchAttackType(), new LoseDexAttackEffect(), 2, 12),
            new MonsterAttack(new HitAttackType(), new BlindAttackEffect(), 10, 5),
            new MonsterAttack(new HitAttackType(), new ParalyzeAttackEffect(), 15, 1)
        };
        public override bool BashDoor => true;
        public override string Description => "She looks like a mortal female with a cat's head.";
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Bast, Goddess of Cats";
        public override int Hdice => 48;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 64;
        public override int Mexp => 30500;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 0;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Bast    ";
        public override bool Unique => true;
    }
}
