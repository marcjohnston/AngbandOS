using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BloodshotIckyThingMonsterRace : MonsterRace
    {
        public override char Character => 'i';
        public override Colour Colour => Colour.Red;
        public override string Name => "Bloodshot icky thing";

        public override int ArmourClass => 18;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Crawl, new AcidAttackEffect(), 2, 4),
        };
        public override string Description => "It is a strange, slimy, icky creature.";
        public override bool DrainMana => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Bloodshot icky thing";
        public override int Hdice => 7;
        public override int Hside => 8;
        public override bool ImmunePoison => true;
        public override int LevelFound => 9;
        public override int Mexp => 24;
        public override int NoticeRange => 14;
        public override bool RandomMove50 => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => " Bloodshot  ";
        public override string SplitName2 => "    icky    ";
        public override string SplitName3 => "   thing    ";
    }
}
