using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GapingMawMonsterRace : MonsterRace
    {
        public override char Character => '·';
        public override string Name => "Gaping Maw";

        public override int ArmourClass => 14;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new TerrifyAttackEffect(), 1, 4),
        };
        public override string Description => "A hole in the fabric of reality, leading to who knows what plane... ";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Gaping Maw";
        public override int Hdice => 21;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 8;
        public override int Mexp => 28;
        public override bool Nonliving => true;
        public override int NoticeRange => 30;
        public override bool PassWall => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Gaping   ";
        public override string SplitName3 => "    Maw     ";
    }
}