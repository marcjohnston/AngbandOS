using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GrooTheWandererMonsterRace : MonsterRace
    {
        protected GrooTheWandererMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightOrange;
        public override string Name => "Groo the Wanderer";

        public override int ArmourClass => 70;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 6, 1),
        };
        public override bool BashDoor => true;
        public override string Description => "He who laughs at Groo's brains will find there is nothing to laugh about... erm, nobody laughs at Groo and lives.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Groo the Wanderer";
        public override int Hdice => 11;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmunePoison => true;
        public override int LevelFound => 33;
        public override bool Male => true;
        public override int Mexp => 2000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 7;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "    Groo    ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => "  Wanderer  ";
        public override bool Troll => true;
        public override bool Unique => true;
        public override bool WeirdMind => true;
    }
}
