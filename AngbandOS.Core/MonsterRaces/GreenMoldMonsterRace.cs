using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GreenMoldMonsterRace : MonsterRace
    {
        public override char Character => 'm';
        public override Colour Colour => Colour.Green;
        public override string Name => "Green mold";

        public override int ArmourClass => 14;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new TerrifyAttackEffect(), 1, 4),
        };
        public override string Description => "It is a strange growth on the dungeon floor.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Green mold";
        public override int Hdice => 21;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 8;
        public override int Mexp => 28;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 2;
        public override int Sleep => 75;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Green    ";
        public override string SplitName3 => "    mold    ";
        public override bool Stupid => true;
    }
}
