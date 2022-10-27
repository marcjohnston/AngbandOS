using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class CarrionCrawlerMonsterRace : MonsterRace
    {
        public override char Character => 'c';
        public override Colour Colour => Colour.Green;
        public override string Name => "Carrion crawler";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Sting, new ParalyzeAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Sting, new ParalyzeAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A hideous centipede covered in slime and with glowing tentacles around its head.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Carrion crawler";
        public override bool Friends => true;
        public override int Hdice => 20;
        public override int Hside => 12;
        public override bool ImmunePoison => true;
        public override int LevelFound => 34;
        public override int Mexp => 100;
        public override int NoticeRange => 15;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Carrion   ";
        public override string SplitName3 => "  crawler   ";
        public override bool WeirdMind => true;
    }
}
