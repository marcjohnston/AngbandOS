namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class HypnosMonsterRace : MonsterRace
    {
        protected HypnosMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new CauseMortalWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DrainManaMonsterSpell(),
            new HoldMonsterSpell(),
            new ScareMonsterSpell(),
            new CreateTrapsMonsterSpell(),
            new ForgetMonsterSpell(),
            new HealMonsterSpell(),
            new SummonCthuloidMonsterSpell(),
            new SummonDemonMonsterSpell(),
            new SummonHiDragonMonsterSpell(),
            new SummonMonstersMonsterSpell(),
            new TeleportAwayMonsterSpell(),
            new TeleportLevelMonsterSpell(),
            new TeleportToMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Hypnos";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 13, 13),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 13, 13),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 13, 13),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 13, 13)
        };
        public override bool BashDoor => true;
        public override string Description => "Beautiful and youthful, this Outer God appears almost human. But appearances can be deceptive.";
        public override bool Drop_1D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Hypnos";
        public override bool GreatOldOne => true;
        public override int Hdice => 69;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 79;
        public override bool Male => true;
        public override int Mexp => 38500;
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
        public override string SplitName3 => "   Hypnos   ";
        public override bool Unique => true;
    }
}
