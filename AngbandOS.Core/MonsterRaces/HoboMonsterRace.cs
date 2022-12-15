using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class HoboMonsterRace : MonsterRace
    {
        public override char Character => 't';
        public override Colour Colour => Colour.Green;
        public override string Name => "Hobo";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Drool, null, 0, 0),
        };
        public override bool BashDoor => true;
        public override string Description => "Ugly doesn't begin to describe him.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Hobo";
        public override int Hdice => 1;
        public override int Hside => 2;
        public override int LevelFound => 0;
        public override bool Male => true;
        public override int Mexp => 0;
        public override int NoticeRange => 6;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Hobo    ";
        public override bool TakeItem => true;
    }
}
