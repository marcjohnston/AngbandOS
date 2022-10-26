using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GreyMoldMonsterRace : Base2MonsterRace
    {
        public override char Character => 'm';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Grey mold";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 4),
        };
        public override string Description => "A small strange growth.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Grey mold";
        public override int Hdice => 1;
        public override int Hside => 2;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 1;
        public override int Mexp => 3;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Grey    ";
        public override string SplitName3 => "    mold    ";
        public override bool Stupid => true;
    }
}
