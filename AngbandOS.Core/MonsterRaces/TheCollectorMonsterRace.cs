using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TheCollectorMonsterRace : MonsterRace
    {
        protected TheCollectorMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new CauseMortalWoundsMonsterSpell(),
            new DrainManaMonsterSpell(),
            new HoldMonsterSpell(),
            new NetherBallMonsterSpell(),
            new ScareMonsterSpell(),
            new CreateTrapsMonsterSpell(),
            new ForgetMonsterSpell(),
            new SummonHiDragonMonsterSpell(),
            new SummonHiUndeadMonsterSpell(),
            new SummonUndeadMonsterSpell(),
            new SummonUniqueMonsterSpell(),
            new TeleportAwayMonsterSpell());
        public override char Character => 'h';
        public override Colour Colour => Colour.Copper;
        public override string Name => "The Collector";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new LoseChaAttackEffect(), 5, 5),
            new MonsterAttack(new TouchAttackType(), new EatItemAttackEffect(), 0, 0),
            new MonsterAttack(new TouchAttackType(), new LoseAllAttackEffect(), 10, 1),
            new MonsterAttack(new TouchAttackType(), new EatGoldAttackEffect(), 0, 0)
        };
        public override bool ColdBlood => true;
        public override string Description => "A strange little gnome, he's been collecting toys and friends and doesn't want to give them up.";
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "The Collector";
        public override int Hdice => 25;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool ImmuneStun => true;
        public override int LevelFound => 52;
        public override bool Male => true;
        public override int Mexp => 45000;
        public override int NoticeRange => 90;
        public override bool OnlyDropItem => true;
        public override int Rarity => 3;
        public override bool Reflecting => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 150;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    The     ";
        public override string SplitName3 => " Collector  ";
        public override bool Unique => true;
    }
}
