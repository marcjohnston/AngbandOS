using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class SpottedMushroomPatchMonsterRace : MonsterRace
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Spotted mushroom patch";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Spore, new PoisonAttackEffect(), 2, 4),
        };
        public override string Description => "Yum! It looks quite tasty.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Spotted mushroom patch";
        public override int Hdice => 1;
        public override int Hside => 1;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 3;
        public override int Mexp => 3;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "  Spotted   ";
        public override string SplitName2 => "  mushroom  ";
        public override string SplitName3 => "   patch    ";
        public override bool Stupid => true;
    }
}
