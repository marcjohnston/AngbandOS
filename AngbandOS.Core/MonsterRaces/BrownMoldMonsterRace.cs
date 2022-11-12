using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BrownMoldMonsterRace : MonsterRace
    {
        public override char Character => 'm';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Brown mold";

        public override int ArmourClass => 12;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new ConfuseAttackEffect(), 1, 4),
        };
        public override string Description => "A strange brown growth on the dungeon floor.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Brown mold";
        public override int Hdice => 15;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 6;
        public override int Mexp => 20;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 1;
        public override int Sleep => 99;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Brown    ";
        public override string SplitName3 => "    mold    ";
        public override bool Stupid => true;
    }
}
