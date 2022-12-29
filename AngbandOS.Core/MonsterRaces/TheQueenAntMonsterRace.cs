using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TheQueenAntMonsterRace : MonsterRace
    {
        protected TheQueenAntMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new SummonAntMonsterSpell());
        public override char Character => 'a';
        public override Colour Colour => Colour.Gold;
        public override string Name => "The Queen Ant";

        public override bool Animal => true;
        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 12),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 12),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 8),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 8)
        };
        public override bool BashDoor => true;
        public override string Description => "She's upset because you hurt her children.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "The Queen Ant";
        public override bool Good => true;
        public override int Hdice => 15;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 37;
        public override int Mexp => 1000;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "    The     ";
        public override string SplitName2 => "   Queen    ";
        public override string SplitName3 => "    Ant     ";
        public override bool Unique => true;
        public override bool WeirdMind => true;
    }
}
