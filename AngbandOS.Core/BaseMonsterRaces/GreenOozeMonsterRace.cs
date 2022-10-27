using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GreenOozeMonsterRace : MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Green ooze";

        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crawl, new AcidAttackEffect(), 1, 3),
        };
        public override string Description => "It's green and it's oozing.";
        public override bool Drop90 => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Green ooze";
        public override int Hdice => 3;
        public override int Hside => 4;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 3;
        public override int Mexp => 4;
        public override int NoticeRange => 8;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Green    ";
        public override string SplitName3 => "    ooze    ";
        public override bool Stupid => true;
    }
}
