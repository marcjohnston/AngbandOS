namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GlaakiMonsterRace : MonsterRace
    {
        protected GlaakiMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new AcidBoltMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new CauseCriticalWoundsMonsterSpell(),
            new CauseMortalWoundsMonsterSpell(),
            new ColdBallMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DrainManaMonsterSpell(),
            new FireBallMonsterSpell(),
            new HoldMonsterSpell(),
            new ManaBoltMonsterSpell(),
            new NetherBallMonsterSpell(),
            new NetherBoltMonsterSpell(),
            new PlasmaBoltMonsterSpell(),
            new ScareMonsterSpell(),
            new WaterBallMonsterSpell(),
            new WaterBoltMonsterSpell(),
            new CreateTrapsMonsterSpell(),
            new DarknessMonsterSpell(),
            new ForgetMonsterSpell(),
            new HealMonsterSpell(),
            new SummonMonsterMonsterSpell(),
            new SummonUndeadMonsterSpell(),
            new TeleportAwayMonsterSpell(),
            new TeleportToMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'X';
        public override string Name => "Glaaki";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 10, 15),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 10, 15),
            new MonsterAttack(new HitAttackType(), new LoseConAttackEffect(), 10, 15),
        };
        public override bool BashDoor => true;
        public override string Description => "Oval bodied with countless thin spines, and three baleful yellow eyes on thin stalks.";
        public override bool Drop_1D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Glaaki";
        public override bool GreatOldOne => true;
        public override int Hdice => 59;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 78;
        public override bool Male => true;
        public override int Mexp => 35500;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Regenerate => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 15;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Glaaki   ";
        public override bool Unique => true;
    }
}
