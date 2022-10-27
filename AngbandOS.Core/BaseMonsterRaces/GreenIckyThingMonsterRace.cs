using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GreenIckyThingMonsterRace : MonsterRace
    {
        public override char Character => 'i';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Green icky thing";

        public override int ArmourClass => 12;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 2, 5),
        };
        public override string Description => "It is a smallish, slimy, icky, acidic creature.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Green icky thing";
        public override int Hdice => 5;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override int LevelFound => 7;
        public override int Mexp => 18;
        public override int NoticeRange => 14;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "   Green    ";
        public override string SplitName2 => "    icky    ";
        public override string SplitName3 => "   thing    ";
    }
}
