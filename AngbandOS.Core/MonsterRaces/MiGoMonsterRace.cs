using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class MiGoMonsterRace : MonsterRace
    {
        public override char Character => 'A';
        public override Colour Colour => Colour.BrightPink;
        public override string Name => "Mi-Go";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Sting, new PoisonAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Bite, new LoseStrAttackEffect(), 1, 2),
        };
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override bool Cthuloid => true;
        public override string Description => "Five feet long pinkish insectoids with a multitude of antennae, with a buzzing voice.";
        public override bool Evil => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Mi-Go";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 15;
        public override int Mexp => 80;
        public override int NoticeRange => 20;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Mi-Go    ";
        public override bool SummonCthuloid => true;
        public override bool SummonMonster => true;
    }
}