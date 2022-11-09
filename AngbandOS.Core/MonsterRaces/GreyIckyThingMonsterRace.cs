using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GreyIckyThingMonsterRace : MonsterRace
    {
        public override char Character => 'i';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Grey icky thing";

        public override int ArmourClass => 12;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new HurtAttackEffect(), 1, 5),
        };
        public override string Description => "It is a smallish, slimy, icky, nasty creature.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Grey icky thing";
        public override int Hdice => 4;
        public override int Hside => 8;
        public override int LevelFound => 5;
        public override int Mexp => 10;
        public override int NoticeRange => 14;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 15;
        public override int Speed => 110;
        public override string SplitName1 => "    Grey    ";
        public override string SplitName2 => "    icky    ";
        public override string SplitName3 => "   thing    ";
    }
}
