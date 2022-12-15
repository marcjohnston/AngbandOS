using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SingingHappyDrunkMonsterRace : MonsterRace
    {
        public override char Character => 't';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Singing, happy drunk";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Beg, null, 0, 0),
        };
        public override bool BashDoor => true;
        public override string Description => "He makes you glad to be sober.";
        public override bool Drop60 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Singing, happy drunk";
        public override int Hdice => 2;
        public override int Hside => 3;
        public override int LevelFound => 0;
        public override bool Male => true;
        public override int Mexp => 0;
        public override int NoticeRange => 10;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Singing   ";
        public override bool TakeItem => true;
    }
}
