using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GriffonMonsterRace : MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "Griffon";

        public override bool Animal => true;
        public override int ArmourClass => 15;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "It is half lion, half eagle. It flies menacingly towards you.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Griffon";
        public override int Hdice => 30;
        public override int Hside => 8;
        public override int LevelFound => 15;
        public override int Mexp => 70;
        public override int NoticeRange => 12;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Griffon   ";
    }
}