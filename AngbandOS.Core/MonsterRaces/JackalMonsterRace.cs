using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class JackalMonsterRace : MonsterRace
    {
        public override char Character => 'C';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Jackal";

        public override bool Animal => true;
        public override int ArmourClass => 3;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 1),
        };
        public override string Description => "It is a yapping snarling dog, dangerous when in a pack.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Jackal";
        public override bool Friends => true;
        public override int Hdice => 1;
        public override int Hside => 4;
        public override int LevelFound => 1;
        public override int Mexp => 1;
        public override int NoticeRange => 10;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Jackal   ";
    }
}