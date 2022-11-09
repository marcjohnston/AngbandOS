using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class WoodSpiderMonsterRace : MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Wood spider";

        public override bool Animal => true;
        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Sting, new PoisonAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "It scuttles towards you.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Wood spider";
        public override bool Friends => true;
        public override int Hdice => 3;
        public override int Hside => 6;
        public override bool ImmunePoison => true;
        public override int LevelFound => 7;
        public override int Mexp => 15;
        public override int NoticeRange => 8;
        public override int Rarity => 3;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Wood    ";
        public override string SplitName3 => "   spider   ";
        public override bool WeirdMind => true;
    }
}
