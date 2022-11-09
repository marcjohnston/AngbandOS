using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class QuiverSlotMonsterRace : MonsterRace
    {
        public override char Character => ',';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Quiver slot";

        public override int ArmourClass => 1;
        public override bool Arrow1D6 => true;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Spore, new ConfuseAttackEffect(), 1, 1),
        };
        public override bool ColdBlood => true;
        public override string Description => "An arrow hole in the floor, covered in fungal tendrils.";
        public override bool EmptyMind => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Quiver slot";
        public override int Hdice => 1;
        public override int Hside => 1;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 10;
        public override int Mexp => 3;
        public override bool Multiply => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 4;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Quiver   ";
        public override string SplitName3 => "    slot    ";
        public override bool Stupid => true;
    }
}
