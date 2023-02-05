namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TheInsaneCrusaderMonsterRace : MonsterRace
    {
        protected TheInsaneCrusaderMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ShriekMonsterSpell(),
            new ScareMonsterSpell(),
            new TeleportToMonsterSpell());
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "The Insane Crusader";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 6, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 6, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8)
        };
        public override bool BashDoor => true;
        public override string Description => "Once a powerful adventurer, this poor fighter has seen a few too many eldritch horrors in his time. Any shred of lucidity is long gone, but he still remains dangerous. He wanders aimlessly through the dungeon randomly stiking at foes both real and imagined, all the while screaming out at the world which caused his condition.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "The Insane Crusader";
        public override int Hdice => 18;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 36;
        public override bool Male => true;
        public override int Mexp => 1200;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "    The     ";
        public override string SplitName2 => "   Insane   ";
        public override string SplitName3 => "  Crusader  ";
        public override bool Unique => true;
    }
}
