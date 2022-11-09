using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class MasterThiefMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Black;
        public override string Name => "Master thief";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new EatGoldAttackEffect(), 4, 4),
            new MonsterAttack(AttackType.Hit, new EatItemAttackEffect(), 4, 5)
        };
        public override bool BashDoor => true;
        public override string Description => "Cool and confident, fast and lithe; protect your possessions quickly!";
        public override bool Drop_2D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Master thief";
        public override int Hdice => 18;
        public override int Hside => 10;
        public override int LevelFound => 34;
        public override bool Male => true;
        public override int Mexp => 350;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 40;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Master   ";
        public override string SplitName3 => "   thief    ";
        public override bool TakeItem => true;
    }
}
